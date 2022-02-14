using Mission.Requrement;
using UnityEngine;

namespace Mission.RequrementBuilder
{
    public abstract class MissionRequirementBuilder : MonoBehaviour
    {
        [SerializeField] protected string title;
        
        public abstract MissionRequirement Build();
    }
}