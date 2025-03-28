using WCSharp.Api;

namespace Source.Extensions
{
    public static class ItemExtensions
    {
        private static readonly (int MinLevel, int MaxLevel, string Color)[] _levelColorRanges =
        {
            (1, 4, "#bfc2be"),    // 1-3 - серый
            (5, 8, "#ffffff"),    // 4-6 - белый
            (9, 12, "#81f542"),    // 7-9 - зеленый
            (13, 16, "#e869ff"), // 10-12 - синий
            (17, 20, "#b342f5"), // фиолетовый  
        };

        public static string ColorizeByLevel(this item item)
        {
            foreach (var range in _levelColorRanges)
            {
                if (item.Level >= range.MinLevel && item.Level <= range.MaxLevel)
                {
                    return item.Name.Colorize(range.Color);
                }
            }

            // Если уровень вне диапазонов (например, 0 или >20), возвращаем цвет по умолчанию
            return item.Name.Colorize("#FFFFFF");
        }
    }
}