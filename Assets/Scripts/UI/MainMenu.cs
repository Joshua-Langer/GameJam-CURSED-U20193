using UnityEngine;
using UnityEngine.SceneManagement;

namespace GJApp.UI
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject m_buttons;
        public GameObject m_howToPlay;
        public GameObject m_credits;
        
        public void QuitGame()
        {
            Application.Quit();
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void HowToPlay()
        {
            m_buttons.SetActive(false);
            m_howToPlay.SetActive(true);
        }

        public void MainMenuReturn()
        {
            SceneManager.LoadScene(0);
        }

        public void Credits()
        {
            m_buttons.SetActive(false);
            m_credits.SetActive(true);
        }
    }
}
