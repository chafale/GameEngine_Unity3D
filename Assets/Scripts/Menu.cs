using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string firstLevel;
    public string tutorialScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene(firstLevel);
    }

    public void StartTutorial() {
        SceneManager.LoadScene(tutorialScreen);
    }
}
