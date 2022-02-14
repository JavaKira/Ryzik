using UnityEngine.Events;

namespace Mission.Requrement
{
    public abstract class MissionRequirement
    {
        public readonly UnityEvent DoneEvent = new UnityEvent();

        protected bool Done;

        private string _title;

        protected MissionRequirement(string title)
        {
            _title = title;
        }

        public override string ToString()
        {
            return _title;
        }
    }
}