using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MissionStartPanel : MonoBehaviour
    {
        private CampaignPoint _currentPoint;

        public void Open(CampaignPoint campaignPoint)
        {
            _currentPoint = campaignPoint;
            GetComponentInChildren<TMP_Text>().text = campaignPoint.Title;
            gameObject.SetActive(true);
        }

        public void StartGame()
        {
            Game.Open(_currentPoint.name, true, _currentPoint.MissionType + "Scene");
        }
    }
}