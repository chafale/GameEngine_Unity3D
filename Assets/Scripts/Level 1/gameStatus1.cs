using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using des = Destroy1;
using mg = GameManager1;

public class gameStatus1 : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI statusText;
    public Player player;

    public static gameStatus1 gameStatusObj;
    public static int score = MapGenerator1.displayCharacter.Count;

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
            Debug.Log("Game end health: "+ FindObjectOfType<Player>().currentHealth);
            statusText.text = "Game Over! :( \n\n The correct word was : " + mg.correct_word + "\nScore : " + ScoringSystem.myScore;

            // Analytics : winStatus, score
            PlayerPrefs.SetInt("winStatus", 0);
            PlayerPrefs.SetInt("score", ScoringSystem.myScore);
            
            // Camera1.GameEnd();
        }
        else
        { //when player wins
            statusText.text = "Congratulations! You Win! \n\n Score : " + ScoringSystem.myScore;
            mg.gamag.WinAudioPlayer.Play();
            // pl.plobj.WinAudioPlayer.Play();
            // Analytics : winStatus, score
            PlayerPrefs.SetInt("winStatus", 1);
            PlayerPrefs.SetInt("score", ScoringSystem.myScore);

            //Camera.GameEnd();
        }
    }

}
