using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using mg = GameManager2_1;
using mapgen = MapGenerator2_1;
using TMPro;
using pl = Player;

public class Camera2_1 : MonoBehaviour
{
    public Player player;
    public GameObject Background;
    public static GameObject overReset;

    public GameObject Hintground;
    public static GameObject goldReset;

    public static GameObject completeLevelUI;

    public AudioSource GameoverBGM;

    public AudioSource GamestartBGM;

    public static Camera2_1 camObj;

    void Awake()
    {
        camObj = this;
    }

    void Start()
    {
        goldScript2_1.goldIndex = 0;
        overReset = GameObject.Find("Background");
        overReset.SetActive(false);
        Time.timeScale = 1;
        GamestartBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.gameOver)
        {
            transform.position += new Vector3(5.5f * Time.deltaTime, 0, 0);
        }
        else
        {
            if (FindObjectOfType<Player>().currentHealth <= 0)
            {
                gameStatus2_1.gameStatusObj.updateStatus();
            }

            Camera2_1.GameEnd();
            //GameEnd();
            player.currentHealth = 0;
            FindObjectOfType<HealthBar>().SetHealth(player.currentHealth);
            Debug.Log("I am obstacle here");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pl.playerSpeed += 3;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            pl.playerSpeed -= 3;
        }
    }

    public void updateBGM()
    {
        GamestartBGM.Stop();
    }

    public static void GameEnd()
    {
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
        GameManager2_1 gameMananger = GameObject.Find("GameManager").GetComponent<GameManager2_1>();
        Time.timeScale = 0;
        goldScript2_1.goldText.text = "";
        overReset.SetActive(true);
        gameMananger.HealPopup.SetActive(false);
        ScoringSystem.myScore = 0;
        mapgen.healCharacters = new List<GameObject>();
        mg.healHolderList = new List<TMP_Text>();
        Camera2_1.camObj.updateBGM();
    }

    public void Reset()
    {
        mg.solvedList = new List<char>();
        mg.letterHolderList = new List<TMP_Text>();
        mg.healHolderList = new List<TMP_Text>();
        mapgen.correctCharacters = new List<GameObject>();
        mapgen.healCharacters = new List<GameObject>();
        mapgen.displayCharacter = new List<GameObject>();
        goldScript2_1.goldText.text = "";
        ScoringSystem.myScore = 0;
        mapgen.healCharacters = new List<GameObject>();
        mg.healHolderList = new List<TMP_Text>();
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