using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PausePanel : MonoBehaviour
    {
        public void OpenMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}