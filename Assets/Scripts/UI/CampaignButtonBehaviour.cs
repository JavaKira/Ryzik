using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CampaignButtonBehaviour : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(Campaign.OpenCampaignRoad);
        }
    }
}