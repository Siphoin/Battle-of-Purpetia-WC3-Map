using Source.Data.Quests;
using Source.Systems;
using Source.Triggers.NPCTriggers.Triggers.TalkTriggers;
using System;
using WCSharp.Api;
using WCSharp.Shared.Data;
using static Source.Extensions.CommonExtensions;

namespace Source.Triggers.NPCTriggers.Triggers.QuestTriggers
{
    public abstract class QuestNPCRegionTrigger : NPCTalkRegionTrigger
    {
        private const int TIME_DIALOG_QUEST_DESCRIPTION = 23;

        protected unit PlayerUnit { get; set; }
        protected bool IsWaitQuest { get; set; }
        protected QuestInstance CurrentQuest { get; private set; }
        protected Action ActionBeforeTransmissionQuestDescription { get; set; }
        protected QuestNPCRegionTrigger(Rectangle region) : base(region)
        {
        }

        protected override void OnPlayerEnterRegion(unit enterUnit)
        {
            if (IsWaitQuest)
            {
                AbortEnterRegion();
                return;
            }
        }

        protected void SetCurrentQuest(QuestInstance quest)
        {
            CurrentQuest = quest;
            QuestSystem.OnQuestStatusChanged += OnQuestStatusChanged;
            IsWaitQuest = true;
        }
        protected virtual void AbortEnterRegion ()
        {
            TransmissionFromUnit(Unit, "Я же просил не беспокоить меня по пустякам, салага!", 4);
        }

        protected virtual void TransmissionQuestDescription ()
        {
            TransmissionFromUnit(Unit, CurrentQuest.GetDescription(), CurrentQuest.GetDescription().Length / TIME_DIALOG_QUEST_DESCRIPTION, ActionBeforeTransmissionQuestDescription, true);
        }
        protected virtual void OnQuestStatusChanged(QuestInstance instance, QuestStatus status)
        {
            if (status == QuestStatus.Completed)
            {
                QuestSystem.OnQuestStatusChanged -= OnQuestStatusChanged;
            }
        }
    }
}
