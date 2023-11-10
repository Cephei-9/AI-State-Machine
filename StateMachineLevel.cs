using System;
using System.Collections.Generic;
using System.Linq;

namespace Cephei.StateMachine
{
    public class StateMachineLevel : StateMachineBase, IPattern
    {
        public event Action EndWorkEvent;

        public LinkedList<ITransition> SimpleTransitions { get; protected set; }
        public LinkedList<ISoftTransition> SoftTransitions { get; protected set; }

        public bool IsActive { get; private set; }

        private IPattern _startPattern;

        private bool _wasInited;

        public StateMachineLevel() => InitAsPattern();

        public void Init(IEnumerable<ITransition> allTransitions, IEnumerable<ISoftTransition> softTransitions, IPattern startPattern, params IPattern[] patterns)
        {
            InitAsMachine(startPattern, patterns);
            InitAsPattern(allTransitions, softTransitions);
        }

        public void InitAsMachine(IPattern startPattern, params IPattern[] patterns)
        {
            _patterns = patterns;
            _startPattern = startPattern;
        }

        public void InitAsPattern(IEnumerable<ITransition> simpleTransitions = null, IEnumerable<ISoftTransition> softTransitions = null)
        {
            InitAsPattern();

            if (simpleTransitions != null)
                SimpleTransitions.AddRange(simpleTransitions);

            if (softTransitions != null)
                SimpleTransitions.AddRange(softTransitions);
        }

        private void InitAsPattern()
        {
            if (_wasInited)
                return;

            _wasInited = true;

            SimpleTransitions = new LinkedList<ITransition>();
            SoftTransitions = new LinkedList<ISoftTransition>();

            EndWorkEvent += () => IPattern.HandleSoftTransition(SoftTransitions);
        }

        public void Activate()
        {
            IsActive = true;
            IPattern.ActivateTransitions(SimpleTransitions, SoftTransitions);

            StartWork(_startPattern);
        }

        public void DeActivate()
        {
            IsActive = false;
            IPattern.DeactivateTransitions(SimpleTransitions, SoftTransitions);

            StopWork();
        }

        public void AddTransition(ITransition transition) =>
            IPattern.AddTransition(transition, SimpleTransitions, SoftTransitions);

        public bool RemoveTransition(ITransition transition) =>
            IPattern.RemoveTransition(transition, SimpleTransitions, SoftTransitions);

        private void SubscribeSoftTransition()
        {
            if (_wasInited == false)
                EndWorkEvent += () => IPattern.HandleSoftTransition(SoftTransitions);

            _wasInited = true;
        }

        protected void InvokeEndWorkEvent() => EndWorkEvent.Invoke();
    }
}