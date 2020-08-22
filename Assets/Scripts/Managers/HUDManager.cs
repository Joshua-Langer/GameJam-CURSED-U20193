using GJApp;
using GJApp.Level;
using GJApp.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text _playerTimeLeft;
    public GameObject _pausePanel;
    public GameObject _medicineItem;
    public GameObject _gameOver;

    void Update()
    {
        PlayerHUD();
        PauseMenu();
        MedicineFound();
        MedicineGone();
        GameOver();
    }

    void PlayerHUD()
    {
        _playerTimeLeft.text = Mathf.Round(LevelManager.l_levelMan.l_lifeTimer).ToString();
    }

    void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.g_gameIsPaused)
        {
            GameManager.instance.g_gameIsPaused = true;
            GameManager.instance.PauseGame();
            _pausePanel.SetActive(true);
            Debug.LogWarning("Escape Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.g_gameIsPaused)
        {
            GameManager.instance.g_gameIsPaused = false;
            GameManager.instance.PauseGame();
            _pausePanel.SetActive(false);
        }
    }

    void MedicineFound()
    {
        if(PlayerManager.p_instance.p_HealItem)
            _medicineItem.SetActive(true);
    }

    void MedicineGone()
    {
        if(!PlayerManager.p_instance.p_HealItem)
            _medicineItem.SetActive(false);
    }

    public void RestartRoom()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        GameManager.instance.MainMenu();
        Time.timeScale = 1;
    }

    void GameOver()
    {
        if(PlayerManager.p_instance.p_health <= 0)
        {
            _gameOver.SetActive(true);
        }
    }

    
}
