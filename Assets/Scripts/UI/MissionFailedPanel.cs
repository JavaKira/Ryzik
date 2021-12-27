using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MissionFailedPanel : MonoBehaviour
    {
        public void Back()
        {
            SceneManager.LoadScene("CampaignRoadScene");
        }
    }
}