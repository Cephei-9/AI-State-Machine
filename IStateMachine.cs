using System;

namespace Cephei.StateMachine
{
    public interface IStateMachine
    {
        IPattern CurentPattern { get; }

        event Action<IPattern> ActivatePatternEvent;

        void StartWork(IPattern statPattern);

        void StopWork();

        void Continue();

        void ActivatePattern(IPattern nextPattern); 

        T GetPatternByType<T>() where T : IPattern;

        bool GetPatternByType<T>(out T pattern) where T : IPattern;

        T GetPatternIs<T>() where T : IPattern;

        bool GetPatternIs<T>(out T pattern) where T : IPattern;

        public static IPattern FindRealPattern(IPattern pattern)
        {
            if (pattern is IStateMachine machine)
                return machine.CurentPattern;

            return pattern;
        }
    }
}
