using System;
using System.Collections.Generic;

namespace Cephei.StateMachine
{
    public abstract class TransitionBase : ITransition
    {
        protected IPattern _nextPattern;
        protected IStateMachine _stateMachine;

        public event Action TransitionEvent;

        public bool IsActive { get; private set; }

        public TransitionBase() { }

        public TransitionBase(IPattern nextPattern, IStateMachine stateMachine) => Init(nextPattern, stateMachine);

        public void Init(IPattern nextPattern, IStateMachine stateMachine)
        {
            _nextPattern = nextPattern;
            _stateMachine = stateMachine;
        }

        public virtual void Activate() =>
            IsActive = true;

        public virtual void DeActivate() =>
            IsActive = false;

        protected void ActivatePattern()
        {
            _stateMachine.ActivatePattern(_nextPattern);
            TransitionEvent?.Invoke();
        }
    }
}
