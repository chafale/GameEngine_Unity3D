using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using des = DestroyEndless;
using mg = GameManagerEndless;


public class gameStatusEndless : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI statusText;
    public Player player;

    public static gameStatusEndless gameStatusObj;
    public static int score = MapGeneratorEndless.displayCharacter.Count;

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
    {  
          
        
            //when health is zero
            if (FindObjectOfType<Player>().currentHealth <= 0 )
            {
            Debug.Log("Game end health: "+ FindObjectOfType<Player>().currentHealth);
            statusText.text = "Game Over! :( \n\n The correct word was : " + mg.correct_word + "\nScore : " + ScoringSystem.myScore;

            // Analytics : winStatus, score
            PlayerPrefs.SetInt("winStatus", 0);
            PlayerPrefs.SetInt("score", ScoringSystem.myScore);

            // Camera4.GameEnd();
        }
        else
        { //when player wins
            statusText.text = "Congratulations! You Win!\n\n Score : " + ScoringSystem.myScore;

            // Analytics : winStatus, score
            PlayerPrefs.SetInt("winStatus", 1);
            PlayerPrefs.SetInt("score", ScoringSystem.myScore);

            //Camera.GameEnd();
        }
    }

}
