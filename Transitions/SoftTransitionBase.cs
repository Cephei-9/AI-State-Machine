namespace Cephei.StateMachine
{
    public abstract class SoftTransitionBase : TransitionBase, ISoftTransition
    {
        public SoftTransitionBase() { }

        public SoftTransitionBase(IPattern nextPattern, IStateMachine stateMachine) 
            : base(nextPattern, stateMachine) { }

        public abstract bool MakeSoftTransition();
    }
}
