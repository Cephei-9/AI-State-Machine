namespace Cephei.StateMachine
{
    public class SoftProgrammingTransition : SoftTransitionBase, IProgrammingTransition
    {
        private bool _canProgrammingTransition;
        private bool _canSoftTransition;

        public SoftProgrammingTransition() { }

        public SoftProgrammingTransition(IPattern nextPattern, IStateMachine stateMachine) 
            : base(nextPattern, stateMachine) { }

        public override void DeActivate()
        {
            base.DeActivate();

            _canProgrammingTransition = false;
            _canSoftTransition = false;
        }

        public override bool MakeSoftTransition()
        {
            _canSoftTransition = true;
            return TryTransition();
        }

        public void MakeTransition()
        {
            if(IsActive)
                _canProgrammingTransition = true;

            TryTransition();
        }

        private bool TryTransition()
        {
            if (_canProgrammingTransition && _canSoftTransition)
            {
                ActivatePattern();
                return true;
            }

            return false;
        }
    }
}
