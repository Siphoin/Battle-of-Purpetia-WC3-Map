using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using WCSharp.SaveLoad;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
namespace Source.Data.SaveableData
{
    public class SaveData : Saveable
    {
        private Dictionary<string, NPCAcquaintanceData> _npcAcquaintanceProgress = new();

        public void SetAcquaintanceProgressWithNPC(unit unit, int startProgress = 0)
        {
            string idUnit = A2S(unit.UnitType);

            if (_npcAcquaintanceProgress.TryGetValue(idUnit, out var data))
            {
                data.IndexAcquaintance++;
            }

            else
            {
                NPCAcquaintanceData newData = new();
                newData.IndexAcquaintance = startProgress;
                _npcAcquaintanceProgress.Add(idUnit, newData);
            }

#if DEBUG
            Console.WriteLine($"current Acquaintance Progress with NPC {unit.Name} as {_npcAcquaintanceProgress[idUnit].IndexAcquaintance}");
#endif
        }

        public int GetAcquaintanceProgressWithNPC(unit unit)
        {
            string idUnit = A2S(unit.UnitType);
            if (_npcAcquaintanceProgress.TryGetValue(idUnit, out var data))
            {
                return data.IndexAcquaintance;
            }
            return 0;
        }
    }
}
