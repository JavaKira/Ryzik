using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CampaignPoint : MonoBehaviour
    {
        [SerializeField] private Color noCompletedColor;
        [SerializeField] private Color completedColor;

        private bool _completed = default;
        private string _title;

        private void Start()
        {
            _title = GetComponentInChildren<TMP_Text>().text;
            
            GetComponent<Image>().color = _completed ? 
                new Color(completedColor.r, completedColor.g, completedColor.b) : 
                new Color(noCompletedColor.r, noCompletedColor.g, noCompletedColor.b);
            
            GetComponent<Button>().onClick.AddListener(Open);
        }

        private void Open()
        {
            Game.Open(_title, true, "EatDefenseScene");
        }
    }
}