using System;
using System.Linq;
using WCSharp.Api;
using static WCSharp.Api.Common;
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

        public static string Colorize(this string text, uint argbColor)
        {
            return text.Colorize(argbColor.ToString("X8"));
        }

        private static bool IsValidHex(string hex)
        {
            return hex.All(c => (c >= '0' && c <= '9') ||
                              (c >= 'A' && c <= 'F'));
        }

        public enum QuestStatus
        {
            Updated,
            Completed,
            Failed,
            Discovered,
            Getted
        }

        public static class QuestMessage
        {
            private const string QuestPrefix = "|cffffcc00Задание|r";

            public static void DisplayQuestMessage(player whichPlayer, QuestStatus status, string message)
            {
                var (statusText, sound) = GetStatusInfo(status);
                var fullMessage = $"{QuestPrefix} {statusText}: {message}";

                DisplayTextToPlayer(whichPlayer, 0, 0, fullMessage);

                    var soundQuest = PlaySound(sound);
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
    }
}
