using System;
using IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CampaignPoint : MonoBehaviour
    {
        [SerializeField] private string title;
        [SerializeField] private MissionTypeBuilder missionType;
        [SerializeField] private CampaignPoint next;
        [SerializeField] private Color noCompletedColor;
        [SerializeField] private Color availableColor;
        [SerializeField] private Color completedColor;

        private CampaignPoint Previous { get; set; }
        public MissionTypeBuilder MissionType => missionType;
        public string Title => title;
        public bool Available { get; private set; }

        private bool _completed = default;
        private Star[] _stars;

        private void Awake()
        {
            _completed = Campaign.Completed(title);
            _stars = GetComponentsInChildren<Star>();
        }

        private void Start()
        {
            UpdateStars();
            UpdateColor();
            
            BuildGraph();
            next.BuildGraph();
            next.UpdateColor();
        }

        private void BuildGraph()
        {
            if (next != null)
                next.Previous = this;    
        }

        private void UpdateColor()
        {
            if (Previous != null && Previous._completed && !_completed)
            {
                Available = true;
            } else if (Previous == null && !_completed)
            {
                Available = true;
            }

            if (Available)
            {
                GetComponent<Image>().color = availableColor;
                return;
            }

            GetComponent<Image>().color = _completed ? 
                new Color(completedColor.r, completedColor.g, completedColor.b) : 
                new Color(noCompletedColor.r, noCompletedColor.g, noCompletedColor.b);
        }

        private void UpdateStars()
        {
            _stars[0].Active = true;
        }

        public void Complete()
        {
            _completed = true;
        }
    }
}