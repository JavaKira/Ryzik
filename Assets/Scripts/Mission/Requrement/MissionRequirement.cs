using UnityEngine.Events;

namespace Mission.Requrement
{
    public abstract class MissionRequirement
    {
        public readonly UnityEvent DoneEvent = new UnityEvent();

        protected bool Done;

        public abstract override string ToString();
    }
}