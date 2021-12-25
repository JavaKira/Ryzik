using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MissionEndPanel : MonoBehaviour
    {
        public void Back()
        {
            SceneManager.LoadScene("CampaignRoadScene");
        }
    }
}