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

        private void Awake()
        {
            _completed = Campaign.Completed(title);
        }

        private void Start()
        {
            SetColor();
            
            BuildGraph();
            next.BuildGraph();
            next.SetColor();
        }

        private void BuildGraph()
        {
            if (next != null)
                next.Previous = this;    
        }

        private void SetColor()
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

        public void Complete()
        {
            _completed = true;
        }

        public void Read(Reads reads)
        {
            _completed = reads.Boolean();
        }

        public void Write(Writes writes)
        {
            writes.Boolean(_completed);
        }
    }
}