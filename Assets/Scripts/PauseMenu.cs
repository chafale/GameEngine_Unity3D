using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    // pause the game
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    // resume functionality
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    // adding home routing
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // rounting to main menu
    }
    // restart functionality
    // level one routing
    public void goToLevel_One()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1");
    }
    // level two restart routing
    public void goToLevel_Two()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_2");
    }

    public void goToLevel_Three()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_3");
    }

    public void goToLevel_Four()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_4");
    }
    public void goToLevel_Genre()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_Genre");
    }
    // Endless runner scene
    public void goToEndless()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Endless");
    }
}
