using WCSharp.Api;

namespace Source.Triggers.Base
{
    public abstract class TriggerInstance
    {
        public abstract trigger GetTrigger();

        public virtual bool IsExeculableByCategory ()
        {
            return true;
        }
    }
}
