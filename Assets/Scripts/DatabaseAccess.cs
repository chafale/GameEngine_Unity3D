using System;
using Proyecto26;
using UnityEngine;

public class DatabaseAccess : MonoBehaviour
{
    private DateTime _gameEndTime;
    // private const string FirebaseURL = "https://csci-526-flappy-kids-default-rtdb.firebaseio.com/";
    private const string FirebaseURL =  "https://csci-526-game-analytics-default-rtdb.firebaseio.com/";
    
    void Start()
    {
        Debug.Log("Database script has started . . . !!!!!");
        
        // Health
        PlayerPrefs.SetInt("health", 100);
        
        // Win status
        PlayerPrefs.SetInt("winStatus", 0);
        
        // Power-ups
        PlayerPrefs.SetInt("hintsCollected", 0);
        PlayerPrefs.SetInt("autofillPowerUp", 0);
        PlayerPrefs.SetInt("speedPowerUp", 0);
        PlayerPrefs.SetInt("medKitPowerUp", 0);
        PlayerPrefs.SetInt("colorChangePowerUp", 0);
        PlayerPrefs.SetInt("healStatus", 0);
        PlayerPrefs.SetInt("goStatus", 0);
        
        // Obstacles
        PlayerPrefs.SetInt("obsBlade",0);
        PlayerPrefs.SetInt("obsFire",0);
        PlayerPrefs.SetInt("obsRod",0);
        PlayerPrefs.SetInt("obsMace",0);
    }
    
    private void OnDisable()
    {
        Debug.Log("On Database disable  . . . !!!");
        
        _gameEndTime = System.DateTime.Now;
        PlayerPrefs.SetString("gameEndTime", _gameEndTime.ToString());
        
        SaveGameStatus();
        SavePowerUps();
        SaveCollidedObstacle();
    }
    
    [Serializable]
    private class GameStatus
    {
        public string registryTime;
        public string levelName;
        public int wordLength;
        public double totalTimePlayed;
        public int winStatus;
        public int score;
        public int health;
    }   
    private void SaveGameStatus()
    {
        //getting gameStartTime
        string startTimeString = PlayerPrefs.GetString("gameStartTime");
        startTimeString = startTimeString.Substring(0, startTimeString.Length-3);
    
        string[] timeSplit = startTimeString.Split(' ');
        if (timeSplit[0].Substring(0,2).Contains("/"))
        {
            startTimeString = startTimeString.Insert(0, "0");
        }
        if (timeSplit[0].Substring(3,2).Contains("/"))
        {
            startTimeString = startTimeString.Insert(3, "0");
        }
        if (timeSplit[1].Substring(0,2).Contains(":"))
        {
            startTimeString = startTimeString.Insert(11, "0");
        }
        Debug.Log(startTimeString);
        DateTime gameStartTime = DateTime.ParseExact(startTimeString, "MM/dd/yyyy HH:mm:ss", null);
        
        var timeDiff = Math.Abs(_gameEndTime.Subtract(gameStartTime).TotalMinutes/1000);
        
        RestClient.Post(FirebaseURL + "game_status.json", new GameStatus()
            {
                registryTime = PlayerPrefs.GetString("gameEndTime"),
                levelName = PlayerPrefs.GetString("levelName"),
                wordLength = PlayerPrefs.GetInt("wordLength"),
                totalTimePlayed = timeDiff,
                winStatus = PlayerPrefs.GetInt("winStatus"),
                score = PlayerPrefs.GetInt("score"),
                health = PlayerPrefs.GetInt("health")
            }
        );
    }
    
    [Serializable]
    private class PowerUps
    {
        public string registryTime;
        public string levelName;
        public int hintObjCount;
        public int autofillCount;
        public int speedIncreaseCount;
        public int medKitCount;
        public int colorChangeCount;
        public int healStatus;
        public int goStatus;
    }
    private void SavePowerUps()
    {
        RestClient.Post(FirebaseURL + "power_ups.json", new PowerUps()
            {
                registryTime = PlayerPrefs.GetString("gameEndTime"),
                levelName = PlayerPrefs.GetString("levelName"),
                hintObjCount = PlayerPrefs.GetInt("hintsCollected"),
                autofillCount = PlayerPrefs.GetInt("autofillPowerUp"),
                speedIncreaseCount = PlayerPrefs.GetInt("speedPowerUp"),
                medKitCount = PlayerPrefs.GetInt("medKitPowerUp"),
                colorChangeCount = PlayerPrefs.GetInt("colorChangePowerUp"),
                healStatus = PlayerPrefs.GetInt("healStatus"),
                goStatus = PlayerPrefs.GetInt("goStatus")
            }
        );
    }

    [Serializable]
    private class Obstacles
    {
        public string registryTime;
        public string levelName;
        public int bladeCollisionCount;
        public int fireCollisionCount;
        public int rodCollisionCount;
        public int maceCollisionCount;
    }
    private void SaveCollidedObstacle()
    {
        RestClient.Post(FirebaseURL + "obstacle.json", new Obstacles()
            {
                registryTime = PlayerPrefs.GetString("gameEndTime"),
                levelName = PlayerPrefs.GetString("levelName"),
                bladeCollisionCount = PlayerPrefs.GetInt("obsBlade"),
                fireCollisionCount = PlayerPrefs.GetInt("obsFire"),
                rodCollisionCount = PlayerPrefs.GetInt("obsRod"),
                maceCollisionCount = PlayerPrefs.GetInt("obsMace")
            }
        );
    }
}