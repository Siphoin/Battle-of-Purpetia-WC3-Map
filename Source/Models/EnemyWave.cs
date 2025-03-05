using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using static WCSharp.Api.Common;
namespace Source.Models
{
    public class EnemyWave
    {
        public Queue<string> Units { get; private set; }
        public int Count => Units.Count;

        public EnemyWave (Dictionary<string, int> data)
        {
            Units = new();
            foreach (var item in data)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    Units.Enqueue(item.Key);
                }
            }
        }

        public void Turn ()
        {
            string id = Units.Dequeue();
            var newUnit = unit.Create(MapConfig.EnemyPlayerWave, FourCC(id), 0, 0);
            unit.Create(Player(0), FourCC(id), 0, 0);
        }
    }
}
