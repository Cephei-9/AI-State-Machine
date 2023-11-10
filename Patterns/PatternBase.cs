using System;
using System.Collections.Generic;
using System.Linq;

namespace Cephei.StateMachine
{
    public abstract class PatternBase : IPattern
    {
        public bool IsActive { get; private set; }

        public event Action EndWorkEvent;

        public LinkedList<ITransition> SimpleTransitions { get; protected set; }

        public LinkedList<ISoftTransition> SoftTransitions { get; protected set; }

        private bool _wasInited;

        public PatternBase() => Init();

        public PatternBase(IEnumerable<ITransition> simpleTransitions = null, IEnumerable<ISoftTransition> softTransitions = null) =>
            Init(simpleTransitions, softTransitions);

        public void Init(IEnumerable<ITransition> simpleTransitions = null, IEnumerable<ISoftTransition> softTransitions = null)
        {
            Init();

            if (simpleTransitions != null)
                SimpleTransitions.AddRange(simpleTransitions);

            if (softTransitions != null)
                SimpleTransitions.AddRange(softTransitions);
        }

        private void Init()
        {
            if (_wasInited)
                return;

            _wasInited = true;

            SimpleTransitions = new LinkedList<ITransition>();
            SoftTransitions = new LinkedList<ISoftTransition>();

            EndWorkEvent += () => IPattern.HandleSoftTransition(SoftTransitions);
        }

        public virtual void Activate()
        {
            IPattern.ActivateTransitions(SimpleTransitions, SoftTransitions);
            IsActive = true;
        }

        public virtual void DeActivate()
        {
            IPattern.DeactivateTransitions(SimpleTransitions, SoftTransitions);
            IsActive = false;
        }

        public void AddTransition(ITransition transition) =>
            IPattern.AddTransition(transition, SimpleTransitions, SoftTransitions);

        public bool RemoveTransition(ITransition transition) =>
            IPattern.RemoveTransition(transition, SimpleTransitions, SoftTransitions);

        protected void InvokeEndWorkEvent() => EndWorkEvent?.Invoke();
    }
}