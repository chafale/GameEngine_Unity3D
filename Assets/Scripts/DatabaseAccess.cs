// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Proyecto26;
// using UnityEngine;
// using UnityEngine.Networking;

// public class DatabaseAccess : MonoBehaviour
// {
//     private DateTime _gameEndTime;

//     void Start()
//     {
//         PlayerPrefs.SetInt("hintsCollected", 0);
//         PlayerPrefs.SetInt("livesLeft", 3);
//     }
    
//     private void OnDisable()
//     {
//         _gameEndTime = System.DateTime.Now;
//         PlayerPrefs.SetString("gameEndTime", _gameEndTime.ToString());
//         SaveStartEndTimeToDatabase();
//         SaveHintsCollected();
//         SaveLivesLeft();
//     }
    
//     [Serializable]
//     public class Timing
//     {
//         public double totalTimePlayed;
//     }   
//     private void SaveStartEndTimeToDatabase()
//     {
//         //getting gameStartTime
//         string startTimeString = PlayerPrefs.GetString("gameStartTime"); 
//         Debug.Log(startTimeString);
//         startTimeString = startTimeString.Substring(0, startTimeString.Length-3);

//         string[] timeSplit = startTimeString.Split(' ');
//         if (timeSplit[0].Substring(0,2).Contains("/"))
//         {
//             startTimeString = startTimeString.Insert(0, "0");
//         }
//         if (timeSplit[1].Substring(0,2).Contains(":"))
//         {
//             startTimeString = startTimeString.Insert(11, "0");
//         }
//         DateTime gameStartTime = DateTime.ParseExact(startTimeString, "MM/dd/yyyy HH:mm:ss", null);
        
//         var result = _gameEndTime.Subtract(gameStartTime).TotalMinutes;
        
//         RestClient.Post("https://csci-526-flappy-kids-default-rtdb.firebaseio.com/game_timing.json", new Timing()
//             {
//                 totalTimePlayed = result
//             }
//         );
//     }

//     [Serializable]
//     class Hints
//     {
//         public string registryTime;
//         public int hintsCollected;
//     }
//     private void SaveHintsCollected()
//     {
//         RestClient.Post("https://csci-526-flappy-kids-default-rtdb.firebaseio.com/game_hints.json", new Hints()
//             {
//                 registryTime = PlayerPrefs.GetString("gameEndTime"),
//                 hintsCollected = PlayerPrefs.GetInt("hintsCollected")
//             }
//         );
//     }

//     [Serializable]
//     class Lives
//     {
//         public string registryTime;
//         public int liveLeft;
//     }
//     private void SaveLivesLeft()
//     {
//         RestClient.Post("https://csci-526-flappy-kids-default-rtdb.firebaseio.com/game_lives.json", new Lives()
//             {
//                 registryTime = PlayerPrefs.GetString("gameEndTime"),
//                 liveLeft = PlayerPrefs.GetInt("livesLeft"),
//             }
//         );
//     }
// }