using System;
using System.Collections.Generic;

namespace Cephei.StateMachine
{
    public interface IPattern
    {
        event Action EndWorkEvent;

        LinkedList<ITransition> SimpleTransitions { get; }

        LinkedList<ISoftTransition> SoftTransitions { get; }

        bool IsActive { get; }

        void Activate();

        void DeActivate();

        void AddTransition(ITransition transition);

        bool RemoveTransition(ITransition transition);


        protected static void HandleSoftTransition(LinkedList<ISoftTransition> softTransition)
        {
            foreach (var transition in softTransition)
            {
                if (transition.MakeSoftTransition())
                    return;
            }
        }

        protected static void AddTransition(ITransition transition, LinkedList<ITransition> simpleTransitions, LinkedList<ISoftTransition> softTransitions)
        {
            if (transition == null)
                return;

            if (transition is ISoftTransition softTransition)
                softTransitions.AddLast(softTransition);
            else
                simpleTransitions.AddLast(transition);
        }

        protected static bool RemoveTransition(ITransition transition, LinkedList<ITransition> simpleTransitions, LinkedList<ISoftTransition> softTransitions)
        {
            if (transition == null)
                return false;

            if (transition is ISoftTransition softTransition)
                return softTransitions.Remove(softTransition);
            else
                return simpleTransitions.Remove(transition);
        }

        protected static void ActivateTransitions(LinkedList<ITransition> simpleTransitions, LinkedList<ISoftTransition> softTransitions) => 
            ActionToTransitions(simpleTransitions, softTransitions, (t) => t.Activate());

        protected static void DeactivateTransitions(LinkedList<ITransition> simpleTransitions, LinkedList<ISoftTransition> softTransitions) =>
            ActionToTransitions(simpleTransitions, softTransitions, (t) => t.DeActivate());

        protected static void ActionToTransitions(LinkedList<ITransition> simpleTransitions, LinkedList<ISoftTransition> softTransitions, Action<ITransition> action)
        {
            foreach (var transition in simpleTransitions)
            {
                action.Invoke(transition);
            }

            foreach (var transition in softTransitions)
            {
                action.Invoke(transition);
            }
        }
    }
}