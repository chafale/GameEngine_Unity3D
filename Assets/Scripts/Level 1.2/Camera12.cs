using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using mapgen = MapGenerator12;
using mg = GameManager12;
using pl = Player;

public class Camera12 : MonoBehaviour
{
    public Player player;

    public GameObject Background;

    public static GameObject overReset;

    public GameObject Hintground;

    public static GameObject goldReset;

    public static GameObject completeLevelUI;

    // Use this for initialization
    public AudioSource GameoverBGM;

    public AudioSource GamestartBGM;

    public static Camera12 camObj;

    void Awake()
    {
        camObj = this;
    }

    void Start()
    {
        goldScript12.goldIndex = 0;
        overReset = GameObject.Find("Background");
        overReset.SetActive(false);

        // goldReset = GameObject.Find("Hintground");
        // goldReset.SetActive(false);
        Time.timeScale = 1;
        GamestartBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.gameOver)
        {
            transform.position += new Vector3(5f * Time.deltaTime, 0, 0);
        }
        else
        {
            if (FindObjectOfType<Player>().currentHealth <= 0)
            {
                gameStatus12.gameStatusObj.updateStatus();
            }
            Camera12.GameEnd();

            //GameEnd();
            player.currentHealth = 0;
            FindObjectOfType<HealthBar>().SetHealth(player.currentHealth);
            Debug.Log("I am obstacle here");
        }

        //if (player.currentHealth == 0)
        // if (player.currentHealth <= 0 )
        // {
        //     //gameStatus.gameStatusObj.updateStatus();
        //     GameEnd();
        //     Debug.Log("I am health here");
        // }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Space key was pressed.");
            pl.playerSpeed += 3;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Debug.Log("Space key was released.");
            pl.playerSpeed -= 3;
        }
    }

    public void updateBGM()
    {
        // AudioListener.pause = true;
        Debug.Log("Update BGM");
        GamestartBGM.Stop();
        Debug.Log("Stopped Gamestart BGM");
        // GameoverBGM.Play();
    }

    public static void GameEnd()
    {
        // GameObject.Find("Background").SetActive(true);
        // AudioListener.pause = true;
        // Camera12.CameraObj.GameoverBGM.Play();
        Camera12.camObj.updateBGM();

        // Debug.Log("Printing   "+Camera12.camObj.GameoverBGM);
        // Camera12.camObj.GameoverBGM.Play();
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

        mg.solvedList = new List<char>();
        mg.letterHolderList = new List<TMP_Text>();
        mg.chars = new List<GameObject>();
        mapgen.displayCharacter = new List<GameObject>();
        mapgen.correctCharacters = new List<GameObject>();
        Time.timeScale = 0;

        // mapgen.displayCharacter = new List<GameObject>();
        goldScript12.goldText.text = "";
        overReset.SetActive(true);
        ScoringSystem.myScore = 0;
    }

    public void Reset()
    {
        Debug.Log("Reset");
        mg.solvedList = new List<char>();
        mg.letterHolderList = new List<TMP_Text>();
        mapgen.correctCharacters = new List<GameObject>();
        mapgen.displayCharacter = new List<GameObject>();
        goldScript12.goldText.text = "";
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
