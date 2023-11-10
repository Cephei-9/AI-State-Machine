namespace Cephei.StateMachine
{
    public class CompositPattern : PatternBase
    {
        private IPattern[] _patterns;

        public CompositPattern(IPattern[] patterns) => _patterns = patterns;

        public override void Activate()
        {
            base.Activate();

            foreach (var pattern in _patterns)
            {
                pattern.EndWorkEvent += InvokeEndWorkEvent;
                pattern.Activate();
            }
        }

        public override void DeActivate()
        {
            base.DeActivate();

            foreach (var pattern in _patterns)
            {
                pattern.EndWorkEvent -= InvokeEndWorkEvent;
                pattern.DeActivate();
            }
        }
    }
}