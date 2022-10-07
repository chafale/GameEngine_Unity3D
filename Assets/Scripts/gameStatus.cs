using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using des = Destroy;
using mg = GameManager;


public class gameStatus : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] TextMeshProUGUI statusText;

    public static gameStatus gameStatusObj;

    void Awake()
    {
        gameStatusObj = this;
    }
    void Start()
    {
        statusText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void updateStatus()
    {
        if (LivesScript.lives == 0)
        {
            statusText.text = "Game Over!\n The correct word was : " + mg.correct_word;
            PlayerPrefs.SetInt("gameStatus", 1);


        }
        else
        {
            statusText.text = "Congratulations!\n You Win!\n The correct word was: " + mg.correct_word;
            PlayerPrefs.SetInt("gameStatus", 1);
        }
    }

}
