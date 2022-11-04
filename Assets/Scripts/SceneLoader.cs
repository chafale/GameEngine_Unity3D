using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// routing to different scenes
public class SceneLoader : MonoBehaviour
{

    public void goToLevel_One()
    {
        
        SceneManager.LoadScene("Level_1");
    }

    public void goToLevel_Two()
    {

        SceneManager.LoadScene("Level_2");
    }

    public void goToLevel_Three()
    {

        SceneManager.LoadScene("Level_3");
    }

    public void goToLevel_Four()
    {

        SceneManager.LoadScene("Level_4");
    }
    public void goToLevel_Genre()
    {
        SceneManager.LoadScene("Level_Genre");
    }
    // Tutorial scene routing
    public void goToTutorial()
    {

        SceneManager.LoadScene("Tutorial");
    }
    // MainMenu scene routing
    public void LoadStartScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
