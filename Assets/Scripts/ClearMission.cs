using System;
using UI;
using UnityEngine;
using UnityEngine.Events;

public class ClearMission : MonoBehaviour
{
    private void Start()
    {
        Map.Instance.Mobs.Changed.AddListener(() =>
        {
            if (CheckEnd())
                End();
        });
    }

    private bool CheckEnd()
    {
        return Map.Instance.Mobs.GetByName("Cockroach").Count == 0;
    }

    private void End()
    {
        FindObjectOfType<MissionEndPanel>().enabled = true;
    }
}