using Mission.Requrement;
using UnityEngine;

namespace Mission.RequrementBuilder
{
    public abstract class MissionRequirementBuilder : MonoBehaviour
    {
        public abstract MissionRequirement Build();
    }
}