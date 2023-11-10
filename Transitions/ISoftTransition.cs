namespace Cephei.StateMachine
{
    public interface ISoftTransition : ITransition
    {
        public bool MakeSoftTransition();
    }
}
