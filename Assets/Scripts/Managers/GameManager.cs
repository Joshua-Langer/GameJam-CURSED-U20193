using GJApp.Board;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GJApp
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;
        BoardManager g_boardManager;
        int level = 80;
        public int g_timeToDie;
        public int g_levelsComplete = 0;
        public bool g_gameIsPaused = false;
        int activeScene;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            //DontDestroyOnLoad(gameObject);
            g_boardManager = GetComponent<BoardManager>();
            InitGame();
        }

        void InitGame()
        {
            g_boardManager.SetupScene(level);
            activeScene = SceneManager.GetActiveScene().buildIndex;
        }

        public void PauseGame()
        {
            if(g_gameIsPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public IEnumerator Restart(int waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(0);
        }

        public void NextLevel()
        {
            level += 40;
            SceneManager.LoadScene(activeScene + 1);
        }

        public void RestartRoom()
        {
            SceneManager.LoadScene(activeScene);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
