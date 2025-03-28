﻿using System;

namespace Source.Systems.WindowsSystems
{
    public abstract class WindowGUIBase 
    {
        public event Action OnExit;
        public event Action OnHide;
        public event Action OnShow;
        public abstract void Destroy();
        public abstract void Show();
        protected virtual void Exit ()
        {
            OnExit?.Invoke();
            Destroy();
        }
        protected virtual void SetHideState(bool state)
        {
            if (state)
            {
                OnHide?.Invoke();
            }

            else
            {
                OnShow?.Invoke();
            }
        }
    }
}
