using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCSharp.Api;
using static WCSharp.Api.Common;
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

        public abstract bool IsRequired();
        
        protected void MarkIsCompleted (bool isCompleted)
        {
            _quest.IsCompleted = isCompleted;
            Console.WriteLine($"Quest completed: {GetTitle()}");
        }
    }
}
