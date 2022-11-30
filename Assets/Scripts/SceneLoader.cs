using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// routing to different scenes
public class SceneLoader : MonoBehaviour
{

    public void goToLevel_OneOne()
    {

        SceneManager.LoadScene("Level_1.1");
    }

    public void goToLevel_OneTwo()
    {

        SceneManager.LoadScene("Level_1.2");
    }

    public void goToLevel_OneThree()
    {

        SceneManager.LoadScene("Level_1.3");
    }

    public void goToLevel_TwoOne()
    {

        SceneManager.LoadScene("Level_2");
    }

    public void goToLevel_TwoTwo()
    {

        SceneManager.LoadScene("Level_2_2");
    }

    public void goToLevel_TwoThree()
    {

        SceneManager.LoadScene("Level_2_3");
    }

    public void goToLevel_ThreeOne()
    {

        SceneManager.LoadScene("Level_3");
    }

    public void goToLevel_ThreeTwo()
    {

        SceneManager.LoadScene("Level_32");
    }

    public void goToLevel_ThreeThree()
    {

        SceneManager.LoadScene("Level_33");
    }

    public void goToLevel_FourOne()
    {
        SceneManager.LoadScene("Level_4");
    }

    public void goToLevel_FourTwo()
    {
        SceneManager.LoadScene("Level_42");
    }

    public void goToLevel_FourThree()
    {
        SceneManager.LoadScene("Level_43");
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

    // Tutorial Size routing
    public void goToSizeTutorial()
    {

        SceneManager.LoadScene("Tutorial SizeChange");
    }

    // Endless runner scene
    public void goToEndless()
    {

        SceneManager.LoadScene("Endless");
    }

    public void goToShape()
    {

        SceneManager.LoadScene("Level_Shape");
    }

    // MainMenu scene routing
    public void LoadStartScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
