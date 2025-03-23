using Source.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using WCSharp.Api;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
using System.Text;
using Source.Systems;
namespace Source.Data.Quests.TypesQuests
{
    public abstract class KillUnitsQuestInstance : QuestInstance
    {
        private Dictionary<string, int> _countersKills = new();
        private Dictionary<string, int> _requireUnits = new();
        private questitem _killQuestItem;
        private trigger _triggerListener;

        protected KillUnitsQuestInstance(player playerOwner) : base(playerOwner)
        {
        }

        protected abstract Dictionary<string, int> GetRequiredUnits();

        public override void Init()
        {
            base.Init();
            _requireUnits = GetRequiredUnits();
            foreach (var unitData in _requireUnits)
            {
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
            if (unit.Owner == GetTargetPlayer() && _requireUnits.ContainsKey(id) && GetKillingUnit().Owner == PlayerOwner)
            {
                if (_countersKills[id] < _requireUnits[id])
                {
                    _countersKills[id]++;
                    UpdateDescriptonQuestItem();
                }
            }

            if (AreDictionariesEqual())
            {
                EndConditions();
            }
        }

        private void EndConditions()
        {
            MarkIsCompleted(true);
            DestroyTrigger(_triggerListener);
            _countersKills.Clear();
            _requireUnits.Clear();
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
            StringBuilder description = new();

            foreach (var unitData in _countersKills)
            {
                var idUnit = unitData.Key;
                var targetUnit = unit.Create(GetTargetPlayer(), FourCC(idUnit), 0, 0);
                var currentCount = unitData.Value.ToString().Colorize(YELOOW_TEXT_HEX);
                var  requireCount = _requireUnits[idUnit].ToString().Colorize(YELOOW_TEXT_HEX);
                var unitName = targetUnit.Name.Colorize(ENEMY_TEXT_HEX);
                description.AppendLine($"Убить {unitName}: {currentCount}/{requireCount}");
                RemoveUnit(targetUnit);
            }

            _killQuestItem.SetDescription(description.ToString());
            QuestSystem.CallEventQuestStatus(this, QuestStatus.Updated);
            QuestMessage.DisplayQuestMessage(PlayerOwner, QuestStatus.Updated, $"\n{description.ToString()}");
        }

#if DEBUG
        public override void MarkIsCompleted_Debug(bool isCompleted)
        {
            EndConditions();
            base.MarkIsCompleted_Debug(isCompleted);
        }
#endif
    }
}
