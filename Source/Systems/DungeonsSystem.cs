using System;
using System.Collections.Generic;
using System.Linq;
using Source.Data.Dungeons;
using Source.Triggers.DungeonsTriggers.Triggers;
using WCSharp.Api;
using WCSharp.Shared;

namespace Source.Systems
{
    public static class DungeonsSystem
    {
        
        private static List<DungeonInstance> _dungeons = new();
        private static Dictionary<DungeonInstance, DungeonRoomData> _notStartedRooms = new();
        private static List<DungeonInstance> _activeDungeons = new();

        public static IEnumerable<DungeonInstance> AvalableDungeons => _dungeons.Where(x => !_activeDungeons.Contains(x));

        public static void RegisterDungeon (DungeonInstance dungeonInstance)
        {
            _dungeons.Add(dungeonInstance);
            var enterRegion = dungeonInstance.GetEnterRegion();
            DungeonRoomZoneTrigger trigger = new DungeonRoomZoneTrigger(dungeonInstance, enterRegion.Region);
            trigger.GetTrigger();
            CreateFloatingText(dungeonInstance);

        }

        public static void TurnDungeon (int index, IEnumerable<player> players)
        {
            var dungeon = _dungeons[index];
            dungeon.Start(players);
            _activeDungeons.Add(dungeon);
            _notStartedRooms.Remove(dungeon);
        }

        public static void TurnDungeon(DungeonInstance instance, IEnumerable<player> players)
        {
            var dungeon = _dungeons.IndexOf(instance);
            TurnDungeon(dungeon, players);
        }

        public static void EndDungeon(DungeonInstance dungeonInstance)
        {
            if (_activeDungeons.Contains(dungeonInstance))
            {
                _activeDungeons.Remove(dungeonInstance);
            }
        }

        public static void RemoveRoom (DungeonInstance dungeonInstance)
        {
            if (_notStartedRooms.TryGetValue(dungeonInstance, out DungeonRoomData room))
            {
                if (!room.GetPlayers().Any())
                {
                    _notStartedRooms.Remove(dungeonInstance);
                }
            }
        }

        public static bool TryJoinDungeon (DungeonInstance dungeon, player player, out DungeonRoomData result)
        {
            result = null;
            if (dungeon.IsCooldown)
            {
                return false;
            }
            if (_activeDungeons.Contains(dungeon))
            {
                return false;
            }
            if (_notStartedRooms.TryGetValue(dungeon, out var roomData))
            {
                roomData.AddPlayer(player);
            }

            else
            {
                result = new(dungeon, player);
                _notStartedRooms.Add(dungeon, result);
            }

            return true;
        }

        private static void CreateFloatingText(DungeonInstance instance)
        {
            var rect = instance.GetEnterRegion();
            // Голубой цвет для названия рейда, желтый для уровня
            string raidText = $"|cff00FFFFРейд {instance.GetDungeonName()}|r |cffffff00Уровень {instance.GetRequiredLevelHero()}|r";

            // Рассчитываем масштаб текста на основе длины строки
            float textScale = CalculateTextScale(raidText.Length); // Функция для расчета масштаба

            // Создаем текст с учетом масштаба
            var text = Util.CreateFloatText(raidText, textScale, rect.Center.X, rect.Center.Y, rect.Height, 255, 255, 255);
            text.SetVelocity(0, 0);
            text.SetLifespan(99999);
            text.SetFadepoint(99999);
        }

        private static float CalculateTextScale(int textLength)
        {
            // Базовый масштаб
            float baseScale = 17f;

            // Максимальная допустимая длина текста для базового масштаба
            int maxLengthForBaseScale = 30;

            // Если текст длиннее, уменьшаем масштаб
            if (textLength > maxLengthForBaseScale)
            {
                float scaleReduction = (textLength - maxLengthForBaseScale) * 0.1f; // Уменьшаем масштаб на 0.1 за каждый лишний символ
                return Math.Max(baseScale - scaleReduction, 10f); // Минимальный масштаб — 10
            }

            return baseScale;
        }

        


    }
}
