using Source.Data.Quests;
using Source.Extensions;
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
        protected unit PlayerUnit { get; set; }
        protected bool IsWaitQuest { get; set; }
        protected QuestInstance CurrentQuest { get; private set; }
        protected QuestNPCRegionTrigger(Rectangle region) : base(region)
        {
        }

        protected void SetCurrentQuest(QuestInstance quest)
        {
            CurrentQuest = quest;
            QuestSystem.OnQuestStatusChanged += OnQuestStatusChanged;
            IsWaitQuest = true;
        }

        protected void UncribeEventQuestCompleted ()
        {
            if (CurrentQuest != null)
            {
                QuestSystem.OnQuestStatusChanged -= OnQuestStatusChanged;
                IsWaitQuest = false;
            }
        }

        protected abstract void OnQuestStatusChanged(QuestInstance instance, QuestStatus status);
    }
}
