using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MissionStartPanel : MonoBehaviour
    {
        public static CampaignPoint LastPoint;

        [SerializeField] private TMP_Text mainRequirementTitle;
        [SerializeField] private TMP_Text firstRequirementTitle;
        [SerializeField] private TMP_Text secondRequirementTitle;
        
        private CampaignPoint _currentPoint;
        private Star[] _stars;

        private void Awake()
        {
            _stars = GetComponentsInChildren<Star>();
        }

        public void Open(CampaignPoint campaignPoint)
        {
            if (!campaignPoint.Available && !campaignPoint.Data.Completed)
                return;
            
            LastPoint = campaignPoint;
            _currentPoint = campaignPoint;
            GetComponentInChildren<TMP_Text>().text = campaignPoint.Title;
            gameObject.SetActive(true);
            
            UpdateStars();
            
            var missionType = _currentPoint.MissionType.Build();
            mainRequirementTitle.text = missionType.MissionEndMainRequirement.ToString();
            firstRequirementTitle.text = missionType.MissionEndRequirements[0].ToString();
            secondRequirementTitle.text = missionType.MissionEndRequirements[1].ToString();
        }

        public void StartGame()
        {
            var missionType = _currentPoint.MissionType.Build();
            missionType.StartMission();
        }

        private void UpdateStars()
        {
            foreach (var star in _stars)
            {
                star.Active = false;
            }

            for (var i = 0; i < _currentPoint.Data.Stars; i++)
            {
                if (i >= _stars.Length)
                    break;
                
                _stars[i].Active = true;
            }
        }
    }
}