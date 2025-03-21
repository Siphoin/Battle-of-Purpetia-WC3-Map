using Source.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
namespace Source.Data.Quests.TypesQuests
{
    public abstract class KillUnitsQuestInstance : QuestInstance
    {
        private Dictionary<string, int> _countersKills = new();
        private Dictionary<string, int> _requireUnits = new();
        private questitem _killQuestItem;
        private trigger _triggerListener;

        protected abstract Dictionary<string, int> GetRequiredUnits();

        public override void Init()
        {
            base.Init();
            _requireUnits = GetRequiredUnits();
            foreach (var unitData in _requireUnits)
            {
                Console.WriteLine(unitData.Key);
                _countersKills.Add(unitData.Key, 0);
            }
        }

        public override trigger GetTrigger()
        {
            _killQuestItem = questitem.Create(Quest);

            _triggerListener = trigger.Create();
            _triggerListener.RegisterPlayerUnitEvent(GetTargetPlayer(), playerunitevent.Death, null);
            _triggerListener.AddAction(TargetUnitDied);
            UpdateDescriptonQuestItem();
            return _triggerListener;
        }

        private void TargetUnitDied()
        {
            var unit = GetTriggerUnit();
            var id = A2S(unit.UnitType);
            if (unit.Owner == GetTargetPlayer() && _requireUnits.ContainsKey(id))
            {
                _countersKills[id]++;
            }

            if (AreDictionariesEqual())
            {
                MarkIsCompleted(true);
                DestroyTrigger(_triggerListener);
                _countersKills.Clear();
                _requireUnits.Clear();
            }
        }

        private bool AreDictionariesEqual()
        {
           bool equals = _countersKills.SequenceEqual(_requireUnits);

            return equals;

        }


        protected abstract player GetTargetPlayer();

        public override IEnumerable<questitem> GetQuestitems()
        {
            questitem[] questitems = new questitem[]
            {
                _killQuestItem,
            };

            return questitems;
        }

        private void UpdateDescriptonQuestItem ()
        {
            string description = string.Empty;

            foreach (var unitData in _countersKills)
            {
                var idUnit = unitData.Key;
                var targetUnit = unit.Create(GetTargetPlayer(), FourCC(idUnit), 10000, 10000);
                var currentCount = unitData.Value;
                var  requireCount = _requireUnits[idUnit];
                var unitName = targetUnit.Name;
                description += $"{unitName}: {currentCount}/{requireCount}\n";
                RemoveUnit(targetUnit);
            }

            _killQuestItem.SetDescription(description);

            Console.WriteLine(description);
        }
    }
}
