using Source.Data.SaveableData;
using System;

namespace Source.Systems
{
    public static class SaveContainerSystem
    {
        public static SaveData SaveData { get; private set; } = new();

        public static void Load ()
        {
            throw new NotImplementedException();
        }

        public static void Save ()
        {
            throw new NotImplementedException();
        }
    }
}
