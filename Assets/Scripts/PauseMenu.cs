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
    public void goToLevel_OneOne()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1.1");
    }
    // level two restart routing
    public void goToLevel_TwoOne()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_2");
    }
    // level three restart routing
    public void goToLevel_ThreeOne()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_3");
    }
    // level four restart routing
    public void goToLevel_FourOne()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_4");
    }

    public void goToLevel_OneTwo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1.2");
    }
    // level two restart routing
    public void goToLevel_TwoTwo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_2_1");
    }
    // level three restart routing
    public void goToLevel_ThreeTwo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_32");
    }
    // level four restart routing
    public void goToLevel_FourTwo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_42");
    }

    public void goToLevel_OneThree()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1.3");
    }
    // level two restart routing
    public void goToLevel_TwoThree()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_2_2");
    }
    // level three restart routing
    public void goToLevel_ThreeThree()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_33");
    }
    // level four restart routing
    public void goToLevel_FourThree()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_43");
    }



    // level genre restart routing
    public void goToLevel_Genre()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_Genre");
    }
    // Endless runner scene restart routing
    public void goToEndless()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Endless");
    }
    // level shape re routing to level shape
    public void goToLevel_Shape()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_Shape");
    }

}
