using System.Collections;
using System.Collections.Generic;
using WCSharp.Api;

namespace Source.Triggers.Base
{
    public abstract class TriggerCategory : IEnumerable<trigger>
    {
        private IEnumerable<TriggerInstance> _instances;
        private IEnumerable<trigger> _triggers;
        public void Execute ()
        {
            Init();

            foreach (var trigger in _triggers)
            {
                trigger.Execute();
            }
        }

        public void Init()
        {
            if (_instances is null)
            {
                _instances = GetAllTriggers();
                List<trigger> triggers = new List<trigger>();

                foreach (var trigger in _instances)
                {
                    triggers.Add(trigger.GetTrigger());
                }

                _triggers = triggers;
            }
        }

        protected abstract IEnumerable<TriggerInstance> GetAllTriggers();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<trigger> GetEnumerator()
        {
            return _triggers.GetEnumerator();
        }
    }
}
