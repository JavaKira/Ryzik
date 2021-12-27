using System;
using Content;
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
        
        Mob.MobDead.AddListener(mob =>
        {
            if (mob.GetComponent<PlayerBehaviour>() != null)
                Failed();
        });
    }

    private bool CheckEnd()
    {
        return Map.Instance.Mobs.GetByName("Cockroach").Count == 0;
    }

    private void Failed()
    {
        FindObjectOfType<MissionFailedPanel>(true).gameObject.SetActive(true);
    }

    private void End()
    {
        FindObjectOfType<MissionEndPanel>(true).gameObject.SetActive(true);
    }
}