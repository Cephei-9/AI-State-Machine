namespace Cephei.StateMachine
{
    public class ProgrammingTransition : TransitionBase, IProgrammingTransition
    {
        public ProgrammingTransition() { }

        public ProgrammingTransition(IPattern nextPattern, IStateMachine stateMachine) 
            : base(nextPattern, stateMachine) { }

        public void MakeTransition()
        {
            if(IsActive)
                ActivatePattern();
        }
    }
}
