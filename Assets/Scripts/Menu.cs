using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string level1;
    public string level2;
    public string level3;
    public string level4;
    public string tutorialLevel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartLevel1() {
        SceneManager.LoadScene(level1);
    }
    public void StartLevel2() {
        SceneManager.LoadScene(level2);
    }
    public void StartLevel3() {
        SceneManager.LoadScene(level3);
    }
    public void StartLevel4() {
        SceneManager.LoadScene(level4);
    }
    public void StartTutorial() {
        SceneManager.LoadScene(tutorialLevel);
    }
}
