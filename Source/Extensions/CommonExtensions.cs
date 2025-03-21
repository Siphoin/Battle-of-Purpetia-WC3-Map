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
    }
}
