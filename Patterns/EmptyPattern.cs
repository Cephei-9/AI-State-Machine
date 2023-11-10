using System.Collections.Generic;

namespace Cephei.StateMachine
{
    public class EmptyPattern : PatternBase
    {
        public EmptyPattern() : base()
        {
        }

        public EmptyPattern(IEnumerable<ITransition> simpleTransitions = null, IEnumerable<ISoftTransition> softTransitions = null) : base(simpleTransitions, softTransitions)
        {
        }
    }
}