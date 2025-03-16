﻿namespace Source.Systems.WindowsSystems
{
    public abstract class WindowGUIBase 
    {
        public abstract void Destroy();
        public abstract void Show();
        protected virtual void Exit ()
        {
            Destroy();
        }
    }
}
