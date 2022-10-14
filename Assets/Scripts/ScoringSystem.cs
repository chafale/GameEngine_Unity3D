using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public static ScoringSystem instance;

    public Text scoreText;
    //public Text highscoreText;
    public static int myScore = 0;
    //public static int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        //highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = " Score : " + myScore.ToString();
        //highscoreText.text = "Highscore : " + highscore.ToString();
    }

    public void AddPoint()
    {
        myScore += 1;
        scoreText.text = "Score : " + myScore.ToString();
        //if (highscore < score)
        //    PlayerPrefs.SetInt("highscore", score);
    }
}



//ScoringSystem.instance.AddPoint();
//public int gamescore = 0;