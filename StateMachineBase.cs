using System;

namespace Cephei.StateMachine
{
    public class StateMachineBase : IStateMachine
    {
        public IPattern CurentPattern { get; private set; }

        public event Action<IPattern> ActivatePatternEvent;

        protected IPattern[] _patterns;

        public void Init(params IPattern[] patterns) => _patterns = patterns;

        public void StartWork(IPattern startPattern)
        {
            CurentPattern = startPattern;
            startPattern.Activate();

            ActivatePatternEvent?.Invoke(CurentPattern);
        }

        public void StopWork() => CurentPattern.DeActivate();

        public void Continue()
        {
            CurentPattern.Activate();

            ActivatePatternEvent?.Invoke(CurentPattern);
        }

        public void ActivatePattern(IPattern nextPattern)
        {
            CurentPattern.DeActivate();
            CurentPattern = nextPattern;
            CurentPattern.Activate();

            ActivatePatternEvent?.Invoke(CurentPattern);
        }

        public T GetPatternByType<T>() where T : IPattern => 
            TypeFinder.GetObjectByType<IPattern, T>(_patterns);

        public bool GetPatternByType<T>(out T pattern) where T : IPattern => 
            TypeFinder.GetObjectByType(_patterns, out pattern);

        public T GetPatternIs<T>() where T : IPattern => 
            TypeFinder.GetObjectIs<IPattern, T>(_patterns);

        public bool GetPatternIs<T>(out T pattern) where T : IPattern => 
            TypeFinder.GetObjectIs(_patterns, out pattern);
    }
}
