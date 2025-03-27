using System;
using System.Collections.Generic;
using WCSharp.Api;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
using Source.Systems;
using System.Linq;
namespace Source.Data.Quests
{
    public abstract class QuestInstance
    {
        private quest _quest;
        private bool _isCreatedQuest;

        public bool IsFailed => _quest.IsFailed;
        public bool IsCompleted { get; private set; }

        public bool IsEnabled => _quest.IsEnabled;
        public int GoldReward { get;  protected set; }
        public int WoodReward { get; protected set; }
        public IEnumerable<string> ItemsRewards { get; protected set; }

        protected quest Quest => _quest;
        public player PlayerOwner {  get; private set; }

        public abstract string GetTitle();
        public abstract string GetDescription();
        public abstract string GetIconPath();
        public abstract trigger GetTrigger();
        public abstract bool IsRequired();
        public virtual void GetRewards ()
        {
            if (!IsCompleted)
            {
                return;
            }

            PlayerResourcesSystem.AddGold(PlayerOwner, GoldReward);
            PlayerResourcesSystem.AddWood(PlayerOwner, WoodReward);

            if (ItemsRewards.Any())
            {
                var items = new List<item>();
                foreach (var itemsIDs in ItemsRewards)
                {
                    var rewardItem = item.Create(FourCC(itemsIDs), 0, 0);
                    items.Add(rewardItem);
                }
                PlayerHeroItemGettingSystem.AddItems(PlayerOwner, items);
            }
        }
        public abstract IEnumerable<questitem> GetQuestitems();

        public QuestInstance(player playerOwner)
        {
            PlayerOwner = playerOwner;
        }

        public virtual void Init ()
        {
            if (_isCreatedQuest)
            {
                return;
            }

            _quest = quest.Create();
            
            _quest.SetTitle(GetTitle());
            _quest.SetDescription(GetDescription());
            _quest.IsRequired = IsRequired();
            _quest.SetIcon(GetIconPath());
            _isCreatedQuest = true;
            
        }
        
        protected void MarkIsCompleted (bool isCompleted)
        {
            if (isCompleted && !_quest.IsCompleted)
            {
                _quest.IsCompleted = isCompleted;
               QuestMessage.DisplayQuestMessage(PlayerOwner, QuestStatus.Completed, GetTitle());
               QuestSystem.CallEventQuestStatus(this, QuestStatus.Completed);
            }
            IsCompleted = isCompleted;
        }

#if DEBUG
        public virtual void MarkIsCompleted_Debug(bool isCompleted)
        {
            MarkIsCompleted(isCompleted);
        }
#endif
    }
}
