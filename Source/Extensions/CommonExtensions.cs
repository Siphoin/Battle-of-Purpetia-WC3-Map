using System;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Extensions
{
    public static class CommonExtensions
    {
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
