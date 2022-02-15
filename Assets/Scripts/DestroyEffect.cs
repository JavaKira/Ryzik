using UnityEngine;
using UnityEngine.Events;

public class DestroyEffect : MonoBehaviour
{
    public UnityEvent started = new UnityEvent();
    
    public void StartEffect()
    {
        started.Invoke();
    }
}