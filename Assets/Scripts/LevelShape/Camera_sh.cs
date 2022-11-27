using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using mg = GameManager_sh;
using mapgen = MapGenerator_sh;
using TMPro;
using pl = Player;

public class Camera_sh : MonoBehaviour {

    public Player player;
    public GameObject Background;
    public static GameObject overReset;

    public GameObject Hintground;
    public static GameObject goldReset;

    public static GameObject completeLevelUI;
    public AudioSource GamestartBGM;
    // Use this for initialization

    public static Camera_sh camObj;

    void Awake()
    {
        camObj = this;
    }

    void Start () {
        goldScript_sh.goldIndex = 0;
        overReset = GameObject.Find("Background");
        overReset.SetActive(false);
        // goldReset = GameObject.Find("Hintground");
        // goldReset.SetActive(false);
        Time.timeScale = 1;
        GamestartBGM.Play();
    }
    // Update is called once per frame
    void Update () {
        if (!player.gameOver)
        {
            transform.position += new Vector3(7.0f * Time.deltaTime, 0, 0);

        }
        else
        {
            if(FindObjectOfType<Player>().currentHealth <= 0){
              gameStatus_sh.gameStatusObj.updateStatus();
            }
            Camera_sh.GameEnd();
            //GameEnd();
            player.currentHealth = 0;
            FindObjectOfType<HealthBar>().SetHealth(player.currentHealth);
            Debug.Log("I am obstacle here");
        }
        //if (player.currentHealth == 0)
        if (player.currentHealth <= 0 )
        {
            //gameStatus.gameStatusObj.updateStatus();
            GameEnd();
            Debug.Log("I am health here");
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Space key was pressed.");
            pl.playerSpeed+=3;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Debug.Log("Space key was released.");
            pl.playerSpeed-=3;
        }


    }
     public void updateBGM()
    {
            GamestartBGM.Stop();
    }
    public static void GameEnd(){
        GameObject[] scoreA;
        GameObject[] healthA;
        scoreA = GameObject.FindGameObjectsWithTag("ScoreAnim");
        healthA = GameObject.FindGameObjectsWithTag("HealthAnim");

        foreach (GameObject scoreAnim in scoreA)
        {
            scoreAnim.SetActive(false);  
        }
        foreach (GameObject healthAnim in healthA)
        {
            healthAnim.SetActive(false);    
        }
        // GameObject.Find("Background").SetActive(true);
        mg.solvedList = new List<char>();
        mg.letterHolderList = new List<TMP_Text>();
        mg.chars = new List<GameObject>();
        mapgen.displayCharacter = new List<GameObject>();
        mapgen.correctCharacters = new List<GameObject>();
        GameManager_sh gameManager = GameObject.Find("GameManager").GetComponent<GameManager_sh>();
        Time.timeScale = 0;
        // mapgen.displayCharacter = new List<GameObject>();
        goldScript_sh.goldText.text="";
        overReset.SetActive(true);
        gameManager.HealPopup.SetActive(false);
    	gameManager.GoPopup.SetActive(false);
        ScoringSystem.myScore = 0;
        mapgen.healCharacters = new List<GameObject>();
        mapgen.goCharacters = new List<GameObject>();
        mg.healHolderList = new List<TMP_Text>();
        mg.goHolderList = new List<TMP_Text>();
        mapgen.activateColorChange = 0;
        CameraGF.camObj.updateBGM();
    }
    public void Reset()
    {
        Debug.Log("Reset");
        mg.solvedList = new List<char>();
        mg.letterHolderList = new List<TMP_Text>();
        mg.healHolderList = new List<TMP_Text>();
        mg.goHolderList = new List<TMP_Text>();
        mapgen.correctCharacters = new List<GameObject>();
        mapgen.healCharacters = new List<GameObject>();
        mapgen.goCharacters = new List<GameObject>();
        mapgen.displayCharacter = new List<GameObject>();
        goldScript_sh.goldText.text="";
        ScoringSystem.myScore = 0;
        mapgen.healCharacters = new List<GameObject>();
        mapgen.goCharacters = new List<GameObject>();
        mg.healHolderList = new List<TMP_Text>();
        mg.goHolderList = new List<TMP_Text>();
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
