using System.Collections.Generic;

namespace Source.Models
{
    public static class WavesList
    {
        public static IEnumerable<EnemyWave> GetAllWaves ()
        {
            EnemyWave[] waves = new EnemyWave[]
            {
                new
                (
                    new Dictionary<string, int>()
                    {
                        {"hpea", 5 },
                    }
                ),

                                new
                (
                    new Dictionary<string, int>()
                    {
                        {"hfoo", 20 },
                    }
                ),
            };

            return waves;
        }
    }
}
