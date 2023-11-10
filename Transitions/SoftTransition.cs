using System;
using System.Collections.Generic;

namespace Cephei.StateMachine
{
    public class SoftTransition : SoftTransitionBase
    {
        public SoftTransition() { }

        public SoftTransition(IPattern nextPattern, IStateMachine stateMachine) 
            : base(nextPattern, stateMachine) { }

        public override bool MakeSoftTransition()
        {
            ActivatePattern();
            return true;
        }
    }
}
