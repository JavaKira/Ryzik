using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CampaignPoint : MonoBehaviour
    {
        [SerializeField] private string title;
        [SerializeField] private string missionType;
        [SerializeField] private Color noCompletedColor;
        [SerializeField] private Color completedColor;

        public string MissionType => missionType;
        public string Title => title;

        private bool _completed = default;

        private void Start()
        {
            GetComponent<Image>().color = _completed ? 
                new Color(completedColor.r, completedColor.g, completedColor.b) : 
                new Color(noCompletedColor.r, noCompletedColor.g, noCompletedColor.b);
        }
    }
}