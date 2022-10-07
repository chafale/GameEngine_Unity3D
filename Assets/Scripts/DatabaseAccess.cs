using System;
using System.Collections;
using System.Collections.Generic;
using Proyecto26;
using UnityEngine;
using UnityEngine.Networking;

public class DatabaseAccess : MonoBehaviour
{
    private DateTime _gameEndTime;

    void Start()
    {
        // gameStatus : 0 - lose 1 - win
        PlayerPrefs.SetInt("gameStatus", 0);
        PlayerPrefs.SetInt("hintsCollected", 0);
        PlayerPrefs.SetInt("livesLeft", 3);
        PlayerPrefs.SetInt("autofillPowerUp", 0);
        PlayerPrefs.SetInt("speedPowerUp", 0);
        PlayerPrefs.SetInt("invisibilityPowerUp", 0);
    }
    
    private void OnDisable()
    {
        _gameEndTime = System.DateTime.Now;
        PlayerPrefs.SetString("gameEndTime", _gameEndTime.ToString());
        SaveGameStatus();
        SaveHintsCollected();
        SaveLivesLeft();
        SavePowerUps();
    }
    
    [Serializable]
    public class GameStatus
    {
        public double totalTimePlayed;
        public int winStatus;
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
        
        var result = _gameEndTime.Subtract(gameStartTime).TotalMinutes/1000;
        
        RestClient.Post("https://csci-526-flappy-kids-default-rtdb.firebaseio.com/game_status.json", new GameStatus()
            {
                totalTimePlayed = result,
                winStatus = PlayerPrefs.GetInt("gameStatus")
            }
        );
    }

    [Serializable]
    class Hints
    {
        public string registryTime;
        public int hintsCollected;
    }
    private void SaveHintsCollected()
    {
        RestClient.Post("https://csci-526-flappy-kids-default-rtdb.firebaseio.com/game_hints.json", new Hints()
            {
                registryTime = PlayerPrefs.GetString("gameEndTime"),
                hintsCollected = PlayerPrefs.GetInt("hintsCollected")
            }
        );
    }

    [Serializable]
    class Lives
    {
        public string registryTime;
        public int livesLeft;
    }
    private void SaveLivesLeft()
    {
        RestClient.Post("https://csci-526-flappy-kids-default-rtdb.firebaseio.com/game_lives.json", new Lives()
            {
                registryTime = PlayerPrefs.GetString("gameEndTime"),
                livesLeft = PlayerPrefs.GetInt("livesLeft"),
            }
        );
    }

    [Serializable]
    class PowerUps
    {
        public string registryTime;
        public int autofillCount;
        public int speedIncreaseCount;
        public int invisibilityCount;
    }
    private void SavePowerUps()
    {
        RestClient.Post("https://csci-526-flappy-kids-default-rtdb.firebaseio.com/power_ups.json", new PowerUps()
            {
                registryTime = PlayerPrefs.GetString("gameEndTime"),
                autofillCount = PlayerPrefs.GetInt("autofillPowerUp"),
                speedIncreaseCount = PlayerPrefs.GetInt("speedPowerUp"),
                invisibilityCount = PlayerPrefs.GetInt("invisibilityPowerUp")
            }
        );
    }
}