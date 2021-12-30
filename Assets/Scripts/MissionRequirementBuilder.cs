using UnityEngine;

public abstract class MissionRequirementBuilder : MonoBehaviour
{
    protected abstract bool Requirements();

    public MissionRequirement Build()
    {
        return new MissionRequirement(Requirements);
    }
}