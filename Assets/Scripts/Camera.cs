using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using mg = GameManager2;
using mapgen = MapGenerator2;
using TMPro;

public class Camera : MonoBehaviour
{
      public Player player;
    public GameObject Background;
   // public static GameObject overReset;

    public GameObject Hintground;
    public static GameObject goldReset;

    public static GameObject completeLevelUI;
    // Start is called before the first frame update
    void Start()
    {
        goldScript2.goldIndex = 0;
        //overReset = GameObject.Find("Background");
        //overReset.SetActive(false);
        // goldReset = GameObject.Find("Hintground");
        // goldReset.SetActive(false);
        Time.timeScale = 1;
    }

   void Update () {
        if (!player.gameOver)
        {
            transform.position += new Vector3(7.0f * Time.deltaTime, 0, 0);

        }
        else
        {
            Camera2.GameEnd();
            //GameEnd();
            player.currentHealth = 0;
            FindObjectOfType<HealthBar>().SetHealth(player.currentHealth);
            gameStatus2.gameStatusObj.updateStatus();
            Debug.Log("I am obstacle here");
        }
        //if (player.currentHealth == 0)
        if (player.currentHealth <= 0 )
        {
            //gameStatus.gameStatusObj.updateStatus();
            GameEnd();
            Debug.Log("I am health here");
        }


    }

    public static void GameEnd(){
        // GameObject.Find("Background").SetActive(true);
        mg.solvedList = new List<char>();
        mg.letterHolderList = new List<TMP_Text>();
        mg.chars = new List<GameObject>();
        mapgen.displayCharacter = new List<GameObject>();
        mapgen.correctCharacters = new List<GameObject>();
        GameManager2 gameMananger = GameObject.Find("GameManager").GetComponent<GameManager2>();
        Time.timeScale = 0;
        // mapgen.displayCharacter = new List<GameObject>();
        goldScript2.goldText.text="";
        //overReset.SetActive(true);
        gameMananger.HealCanvas.SetActive(false);
    }
    public void Reset()
    {
        Debug.Log("Reset");
        mg.solvedList = new List<char>();
        mg.letterHolderList = new List<TMP_Text>();
        mg.healHolderList = new List<TMP_Text>();
        mapgen.correctCharacters = new List<GameObject>();
        mapgen.healCharacters = new List<GameObject>();
        mapgen.displayCharacter = new List<GameObject>();
        goldScript2.goldText.text="";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void Pause()
    {
        Time.timeScale = 0;
        goldReset.SetActive(true);
    }
    public static void Resume()
    {
        Time.timeScale = 1;
        goldReset.SetActive(false);
    }
    public static void CompleteLevel()
    {

        completeLevelUI.SetActive(true);
    }
}
