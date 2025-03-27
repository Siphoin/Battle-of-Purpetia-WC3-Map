using System;

namespace Source.Systems.WindowsSystems
{
    public abstract class WindowGUIBase 
    {
        public event Action OnExit;
        public abstract void Destroy();
        public abstract void Show();
        protected virtual void Exit ()
        {
            OnExit?.Invoke();
            Destroy();
        }
    }
}
