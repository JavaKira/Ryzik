using System;
using IO;
using Mission;
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
        
        private Star[] _stars;

        public CampaignPointData Data;

        private void Awake()
        {
            var data = Campaign.GetData(title);
            Data = data ?? new CampaignPointData(title);
            _stars = GetComponentsInChildren<Star>();
        }

        private void Start()
        {
            UpdateStars();
            UpdateColor();
            
            if (next == null) return;
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
            if (Previous != null && Previous.Data.Completed && !Data.Completed)
            {
                Available = true;
            } else if (Previous == null && !Data.Completed)
            {
                Available = true;
            }

            if (Available)
            {
                GetComponent<Image>().color = availableColor;
                return;
            }

            GetComponent<Image>().color = Data.Completed ? 
                new Color(completedColor.r, completedColor.g, completedColor.b) : 
                new Color(noCompletedColor.r, noCompletedColor.g, noCompletedColor.b);
        }

        private void UpdateStars()
        {
            for (var i = 0; i < Data.Stars; i++)
            {
                if (i >= _stars.Length)
                    break;
                
                _stars[i].Active = true;
            }
        }

        public void Complete()
        {
            Data.Completed = true;
        }
        
        public class CampaignPointData
        {
            public readonly string CampaignPointTitle;
            public bool Completed;
            public int Stars;

            public CampaignPointData(string campaignPointTitle)
            {
                CampaignPointTitle = campaignPointTitle;
            }

            public void Read(Reads reads)
            {
                Completed = reads.Boolean();
                Stars = reads.Int();
            }

            public void Write(Writes writes)
            {
                writes.Boolean(Completed);
                writes.Int(Stars);
            }
        }
    }
}