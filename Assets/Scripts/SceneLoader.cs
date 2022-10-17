using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void goToTutorial()
    {

        SceneManager.LoadScene("Tutorial");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
}
