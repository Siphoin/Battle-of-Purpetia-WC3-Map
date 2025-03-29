using Source.Data.Dungeons;
using Source.Data.Inventory;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using WCSharp.Events;
using static WCSharp.Api.Common;
using static WCSharp.Api.Blizzard;
namespace Source.Extensions
{
    public static class CommonExtensions
    {
        public const string YELOOW_TEXT_HEX = "#f5f242";
        public const string RED_TEXT_HEX = "#f54242";
        public const string BLUE_TEXT_HEX = "#424ef5";
        public const string GREEN_TEXT_HEX = "#81f542";
        public const string ENEMY_TEXT_HEX = "#cc3a35";
        public const string DEFAULT_WARCRAFT_III_TEXT_HEX = "#ffffcc";

        #region DB Item Prices
        private static readonly Dictionary<string, int> _itemsPrices = new Dictionary<string, int>()
    {
        // Постоянные предметы (Permanent)
        {"wlsd", 150},    // Ankh of Reincarnation
        
    };
        #endregion

        #region Targeted Items DB
        private static readonly HashSet<int> itemTargetedsIds = new HashSet<int>()
        {
           FourCC("ssil"), // Посох немоты
           Constants.ITEM_FPEM, // Мясо рыболюда
           // ПОСТОЯННЫЕ
            FourCC("stel"), // Посох Телепортации
            // ИМЕЮЩИЕ ЗАРЯДЫ
            FourCC("wshs"), // Жезл Чужих глаз
            FourCC("woms"), // Жезл Похищения маны
            FourCC("wlsd"), // Жезл Молний
            FourCC("will"), // Жезл Иллюзий
            FourCC("wcyc"), // Жезл Ветров
            // АРТЕФАКТЫ
            FourCC("desc"), // Кинжал мага
            // ПОДЛЕЖАЩИЕ ПРОДАЖЕ
            FourCC("ssan"), // Посох Спасения
            FourCC("silk"), // Моток паутины
            FourCC("hslv"), // Лечебный эликсир
            FourCC("wneu"), // Жезл Рассеивания
            FourCC("hlsv"), // Лечебный бальзам
            // РАЗНЫЕ
            FourCC("shtm"), // Шаманский тотем
            FourCC("ccmd"), // Скипетр Власти
            FourCC("spre"), // Посох Возвращения
            FourCC("gvsm"), // Перчатки волшебника
            FourCC("crdt"), // Корона Смерти
            FourCC("tmsc"), // Книга Жертв
            FourCC("schl"), // Жезл Исцеления
            FourCC("esaz"), // Душа Азуны

        };
        #endregion

#if DEBUG
        public static bool IsFastTransmissionUnit { get; set; } = false;
#endif
        public static string A2S(int value)
        {
            string result = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                // Извлекаем очередной байт, начиная с младшего (LSB)
                byte currentByte = (byte)((value >> (i * 8)) & 0xFF);
                // Добавляем символ в начало строки
                result = ((char)currentByte) + result;
            }
            return result;
        }

        public static bool IsHero (this unit unit)
        {
            return !string.IsNullOrEmpty(unit.HeroName);
        }

        public static void TransmissionFromUnit(unit whichUnit, string message, float time, Action action = null, bool isWait = true)
        {
#if DEBUG
            if (IsFastTransmissionUnit)
            {
                time = 1;
            }
#endif
            trigger triggerSpeak = trigger.Create();
            triggerSpeak.AddAction(() =>
            {
                SetCinematicScene(whichUnit.UnitType, whichUnit.Owner.Color, whichUnit.Name, message, time, message.Length / 10);
                if (isWait)
                {
                    if (action != null)
                    {

                        timer timerAction = timer.Create();
                        timerAction.Start(time, false, () =>
                        {
                            action?.Invoke();
                            DestroyTimer(timerAction);
                        });
                    }


                }

                else
                {
                    action?.Invoke();
                }
                DestroyTrigger(triggerSpeak);
            });

            triggerSpeak.Execute();
        }

        public static void ExecuteActionFromTime(float time, Action action)
        {
            timer timerExecution = timer.Create();
            timerExecution.Start(time, false, () =>
            {
                action?.Invoke();
                DestroyTimer(timerExecution);
            });
        }

        public static void PauseUnitWithStand(unit unit)
        {
            IssueImmediateOrder(unit, "stop");
            PauseUnit(unit, true);
        }

        public static sound PlaySound(string soundName)
        {
            sound newSound = CreateSound(soundName, false, false, false, 12700, 12700, string.Empty);
            return PlaySound(newSound);
        }

        public static sound PlaySound(sound sound)
        {
            sound.Start();
            KillSoundWhenDone(sound);
            return sound;
        }
        


        public static string Colorize(this string text, string hexColor)
        {
            if (string.IsNullOrEmpty(text)) return text;

            // Нормализация HEX-строки
            var cleanHex = hexColor
                .Replace("#", "")
                .Replace("0x", "")
                .Trim()
                .ToUpper();

            // Добавление альфа-канала по умолчанию
            if (cleanHex.Length == 6)
                cleanHex = "FF" + cleanHex;

            // Валидация HEX
            if (cleanHex.Length != 8 || !IsValidHex(cleanHex))
                return text;

            return $"|c{cleanHex}{text}|r";
        }

        private static bool IsValidHex(string hex)
        {
            return hex.All(c => (c >= '0' && c <= '9') ||
                              (c >= 'A' && c <= 'F'));
        }

        public static int GetItemGoldCost(item item)
        {
            try
            {
                return _itemsPrices.Where(x => FourCC(x.Key) == item.TypeId).First().Value;
            }
            catch
            {
                DisplayTextToPlayer(player.LocalPlayer, 0, 0, $"Предмет {item.Name} не найден в базе данных цен.");
                return 100;
            }
        }

        public static bool IsTargetedItem (item item)
        {
            return itemTargetedsIds.Contains(item.TypeId);
        }

        public static float GetItemColldown (item item)
        {
            var ability = BlzGetItemAbilityByIndex(item, 0);
            var value = BlzGetAbilityRealLevelField(ability, ABILITY_RLF_COOLDOWN, ability.Levels);
            return value;
        }

        public static bool IsItemColldown (item item)
        {
            return GetItemColldown(item) > 0;
        }


        public enum QuestStatus
        {
            Updated,
            Completed,
            Failed,
            Discovered,
            Getted
        }

        public enum MessagePlayerType
        {
            Success,
            Failed,
            Hint,
        }

        public static class QuestMessage
        {
            private const string QuestPrefix = "|cffffcc00Задание|r";

            public static void DisplayQuestMessage(player whichPlayer, QuestStatus status, string message)
            {
                var (statusText, sound) = GetStatusInfo(status);
                var fullMessage = $"{QuestPrefix} {statusText}: {message}";

                DisplayTextToPlayer(whichPlayer, 0, 0, fullMessage);

                    var soundQuest = PlaySound("Error");
                    soundQuest.Start();

                
            }

            private static (string statusText, sound sound) GetStatusInfo(QuestStatus status)
            {
                return status switch
                {
                    QuestStatus.Updated => ("|cff00ff00обновилось|r", CreateSoundFromLabel("QuestUpdate", false, false, false, 10000, 10000)),
                    QuestStatus.Completed => ("|cff00ff00выполнено|r", CreateSoundFromLabel("QuestCompleted", false, false, false, 10000, 10000)),
                    QuestStatus.Failed => ("|cffff0000провалено|r", CreateSoundFromLabel("QuestFailed", false, false, false, 10000, 10000)),
                    QuestStatus.Discovered => ("|cff00ff00обнаружено|r", CreateSoundFromLabel("Hint", false, false, false, 10000, 10000)),
                    QuestStatus.Getted => ("|cffffcc00получено|r", CreateSoundFromLabel("QuestNew", false, false, false, 10000, 10000)),
                    _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
                };
            }
        }

        public static class PlayerMessage
        {

            public static void DisplayPlayerMessage(player whichPlayer, MessagePlayerType type, string message)
            {
                var (statusText, sound) = GetStatusInfo(type);
                var fullMessage = $"{statusText}: {message}";

                DisplayTextToPlayer(whichPlayer, 0, 0, fullMessage);

                var soundQuest = PlaySound(sound);
                soundQuest.Start();


            }

            private static (string statusText, sound sound) GetStatusInfo(MessagePlayerType type)
            {
                return type switch
                {
                    MessagePlayerType.Failed => ("|cffff0000Не получилось|r", CreateSoundFromLabel("Sounds\\UI\\Error.wav", false, false, false, 17000, 17000)),
                    MessagePlayerType.Success => ("|cff00ff00Успешно|r", CreateSoundFromLabel("MagicClick", false, false, false, 17000, 1000)),
                    MessagePlayerType.Hint => ("|cff00ff00Подсказка|r", CreateSoundFromLabel("Hint", false, false, false, 17000, 17000)),
                    _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
                };
            }
        }
    }
}
