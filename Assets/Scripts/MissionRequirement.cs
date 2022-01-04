using System;
using UnityEngine.Events;

public abstract class MissionRequirement
{
    public readonly UnityEvent DoneEvent = new UnityEvent();

    protected bool Done;
}