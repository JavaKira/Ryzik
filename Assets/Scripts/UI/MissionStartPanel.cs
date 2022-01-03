using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MissionStartPanel : MonoBehaviour
    {
        public static CampaignPoint LastPoint;
        
        private CampaignPoint _currentPoint;

        public void Open(CampaignPoint campaignPoint)
        {
            if (!campaignPoint.Available && !campaignPoint.Data.Completed)
                return;
            
            LastPoint = campaignPoint;
            _currentPoint = campaignPoint;
            GetComponentInChildren<TMP_Text>().text = campaignPoint.Title;
            gameObject.SetActive(true);
        }

        public void StartGame()
        {
            var missionType = _currentPoint.MissionType.Build();
            missionType.StartMission();
        }
    }
}