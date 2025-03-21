using System;
using System.Collections.Generic;
using WCSharp.Api;
using static WCSharp.Api.Common;
using static Source.Extensions.CommonExtensions;
namespace Source.Data.Quests
{
    public abstract class QuestInstance
    {
        private quest _quest;
        private bool _isCreatedQuest;

        public bool IsFailed => _quest.IsFailed;

        public bool IsEnabled => _quest.IsEnabled;

        protected quest Quest => _quest;
        public player PlayerOwner {  get; private set; }

        public abstract string GetTitle();
        public abstract string GetDescription();
        public abstract string GetIconPath();
        public abstract trigger GetTrigger();
        public abstract bool IsRequired();
        public abstract IEnumerable<questitem> GetQuestitems();

        public QuestInstance(player playerOwner)
        {
            PlayerOwner = playerOwner;
        }

        public virtual void Init ()
        {
#if DEBUG
            Console.WriteLine($"Created new quest {GetTitle()}");
#endif
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
            _quest.IsCompleted = isCompleted;
            if (isCompleted)
            {
               QuestMessage.DisplayQuestMessage(PlayerOwner, QuestStatus.Completed, GetTitle());
            }
            Console.WriteLine($"Quest completed: {GetTitle()}");
        }
    }
}
