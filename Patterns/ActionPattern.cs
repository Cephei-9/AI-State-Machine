using System;
using System.Collections.Generic;

namespace Cephei.StateMachine
{
    public class ActionPattern : PatternBase
    {
        public IPattern ChildPattern;

        public Action ActivateAction;
        public Action DeActivateAction;

        public ActionPattern() { }

        public ActionPattern(IEnumerable<ITransition> simpleTransition, IEnumerable<ISoftTransition> softTransition) 
            : base(simpleTransition, softTransition) { }

        public ActionPattern(IPattern childPattern = null, Action activateAction = null, Action deActivateAction = null) =>
            Init(childPattern, activateAction, deActivateAction);        

        public void Init(IPattern childPattern = null, Action activateAction = null, Action deActivateAction = null)
        {
            ChildPattern = childPattern;
            ActivateAction = activateAction;
            DeActivateAction = deActivateAction;            
        }

        public override void Activate()
        {
            base.Activate();

            ChildPattern?.Activate();
            ChildPattern.EndWorkEvent += InvokeEndWorkEvent;

            ActivateAction?.Invoke();
        }

        public override void DeActivate()
        {
            base.DeActivate();

            ChildPattern?.DeActivate();
            ChildPattern.EndWorkEvent -= InvokeEndWorkEvent;

            DeActivateAction?.Invoke();
        }
    }
}