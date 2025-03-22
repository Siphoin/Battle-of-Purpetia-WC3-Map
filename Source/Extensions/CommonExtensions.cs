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
            Discovered
        }

        public static class QuestMessage
        {
            private const string QuestPrefix = "|cffffcc00Задание|r";

            public static void DisplayQuestMessage(player whichPlayer, QuestStatus status, string message)
            {
                var (statusText, soundPath) = GetStatusInfo(status);
                var fullMessage = $"{QuestPrefix} {statusText}: {message}";

                DisplayTextToPlayer(whichPlayer, 0, 0, fullMessage);

                if (!string.IsNullOrEmpty(soundPath))
                {
                    soundPath = soundPath.Replace(@"\", "/");
                    var soundQuest = sound.CreateFromLabel(soundPath, false, false, false, 12700, 12700);
                    soundQuest.Start();

                }
            }

            private static (string statusText, string soundPath) GetStatusInfo(QuestStatus status)
            {
                return status switch
                {
                    QuestStatus.Updated => ("|cff00ff00обновилось|r", @"Sound\Interface\QuestNew.wav"),
                    QuestStatus.Completed => ("|cff00ff00выполнено|r", @"Sound\Interface\QuestCompleted.wav"),
                    QuestStatus.Failed => ("|cffff0000провалено|r", @"Sound\Interface\QuestFailed.wav"),
                    QuestStatus.Discovered => ("|cff00ff00обнаружено|r", @"Sound\Interface\QuestNew.wav"),
                    _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
                };
            }
        }
    }
}
