using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using des = Destroy33;
using mg = GameManager33;


public class gameStatus33 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI statusText;
    public Player player;

    public static gameStatus33 gameStatusObj;
    public static int score = MapGenerator33.displayCharacter.Count;

    void Awake()
    {
        gameStatusObj = this;
    }
    void Start()
    {
        statusText = GetComponent<TMPro.TextMeshProUGUI>();
        player = gameObject.AddComponent<Player>();
    }

    // Update is called once per frame
    public void updateStatus()
    {   //when health is zero

        if (FindObjectOfType<Player>().currentHealth <= 0 )
        {
            mg.gamag.LoseAudioPlayer.Play();
            Debug.Log("Game end health: "+ FindObjectOfType<Player>().currentHealth);
            statusText.text = "Game Over! :( \n\n The correct word was : " + mg.correct_word + "\nScore : " + ScoringSystem.myScore;
            // Analytics : winStatus, score
            PlayerPrefs.SetInt("winStatus", 0);
            PlayerPrefs.SetInt("score", ScoringSystem.myScore);

            // Camera33.GameEnd();
        }
        else
        { //when player wins
            mg.gamag.WinAudioPlayer.Play();
            statusText.text = "Congratulations! You Win!\n\n Score : " + ScoringSystem.myScore;
            // Analytics : winStatus, score
            PlayerPrefs.SetInt("winStatus", 1);
            PlayerPrefs.SetInt("score", ScoringSystem.myScore);

            //Camera.GameEnd();
        }
    }

}
