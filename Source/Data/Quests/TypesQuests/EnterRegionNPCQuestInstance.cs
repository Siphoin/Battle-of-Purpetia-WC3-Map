using System.Collections.Generic;
using WCSharp.Api;
using static WCSharp.Api.Common;

namespace Source.Data.Quests.TypesQuests
{
    public abstract class EnterRegionNPCQuestInstance : QuestInstance
    {
        private questitem _questItem;
        private trigger _triggerListener;
        protected EnterRegionNPCQuestInstance(player playerOwner) : base(playerOwner)
        {
        }

        public override trigger GetTrigger()
        {
            _questItem = questitem.Create(Quest);

            _triggerListener = trigger.Create();
            _triggerListener.RegisterEnterRegion(GetEnterRegion(), null);
            _triggerListener.AddAction(EndQuest);
            return _triggerListener;
        }

        protected abstract region GetEnterRegion();

        private void EndQuest()
        {
            MarkIsCompleted(true);
            DestroyTrigger(_triggerListener);
            GetRewards();
        }

        public override IEnumerable<questitem> GetQuestitems()
        {
            questitem[] questitems = new questitem[]
            {
                _questItem,
            };

            return questitems;
        }

#if DEBUG
        public override void MarkIsCompleted_Debug(bool isCompleted)
        {
            EndQuest();
            base.MarkIsCompleted_Debug(isCompleted);
        }
#endif
    }
}
