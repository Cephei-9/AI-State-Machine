using System;

namespace Cephei.StateMachine
{
    public class ConditionSoftTransition : SoftTransitionBase
    {
        public Func<bool> Condition;

        public ConditionSoftTransition(IPattern nextPattern, IStateMachine stateMachine, Func<bool> condition) : base(nextPattern, stateMachine) 
            => Condition = condition;

        public override bool MakeSoftTransition()
        {
            bool conditionValue = Condition == null ? false : Condition.Invoke();

            if (conditionValue) 
                ActivatePattern();

            return conditionValue;
        }
    }
}
