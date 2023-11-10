using System;

namespace Cephei.StateMachine
{
    public interface ITransition
    {
        public bool IsActive { get; }

        public event Action TransitionEvent;

        public abstract void Activate();

        public abstract void DeActivate();
    }
}