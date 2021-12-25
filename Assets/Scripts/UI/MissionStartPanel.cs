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
            gameObject.SetActive(true);
        }

        public void StartGame()
        {
            Game.Open(_currentPoint.name, true, "EatDefenseScene");
        }
    }
}