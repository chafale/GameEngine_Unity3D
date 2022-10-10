using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using des = Destroy;
using mg = GameManager;


public class gameStatus : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] TextMeshProUGUI statusText;
    public Player player;
    
    public static gameStatus gameStatusObj;

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
            statusText.text = "Game Over!\n The correct word was : " + mg.correct_word;
            PlayerPrefs.SetInt("gameStatus", 1);
            Camera.GameEnd();
        }
        else
        { //when player wins
            statusText.text = "Congratulations!\n You Win!\n The correct word was: " + mg.correct_word;
            PlayerPrefs.SetInt("gameStatus", 1);
            // Camera.GameEnd();
        }
    }

}
