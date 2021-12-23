using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private bool startAtStart;
    [SerializeField] private float defaultTime;

    public UnityEvent onEnd;
    
    private void Start()
    {
        if (startAtStart) 
            StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(StartEnumerator(defaultTime));
    }

    public void StartTimer(float time)
    {
        StartCoroutine(StartEnumerator(time));
    }

    private IEnumerator StartEnumerator(float time)
    {
        yield return new WaitForSeconds(time);
        
        onEnd.Invoke();
    }
}