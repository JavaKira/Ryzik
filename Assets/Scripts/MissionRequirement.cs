using System;
using UnityEngine.Events;

public class MissionRequirement
{
    public readonly UnityEvent DoneEvent = new UnityEvent();
    public delegate bool Requirements();
    
    private Requirements _requirements;

    public MissionRequirement(Requirements requirements)
    {
        _requirements = requirements;
    }

    public void Update()
    {
        if (_requirements.Invoke())
        {
            DoneEvent.Invoke();
        }
    }

    protected void Done()
    {
        DoneEvent.Invoke();
    }
}