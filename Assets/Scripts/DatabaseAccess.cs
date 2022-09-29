using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using UnityEngine;

public class DatabaseAccess : MonoBehaviour
{
    private MongoClient _client = new MongoClient("mongodb+srv://chafale:Password@flappykids.hpnerhl.mongodb.net/?retryWrites=true&w=majority");
    private IMongoDatabase _database;
    private DateTime _gameEndTime;
    private IMongoCollection<BsonDocument> _timingCollection;
    private IMongoCollection<BsonDocument> _hintsCollection;
    private IMongoCollection<BsonDocument> _livesCollection;

    void Start()
    {
        PlayerPrefs.SetInt("hintsCollected", 0);
        PlayerPrefs.SetInt("livesLeft", 3);
        _database = _client.GetDatabase("Analytics");
        _timingCollection = _database.GetCollection<BsonDocument>("timing");
        _hintsCollection = _database.GetCollection<BsonDocument>("hints");
        _livesCollection = _database.GetCollection<BsonDocument>("lives");
    }

    private void OnApplicationQuit()
    {
        _gameEndTime = System.DateTime.Now;
        PlayerPrefs.SetString("gameEndTime", _gameEndTime.ToString());
        SaveStartEndTimeToDatabase();
        SaveHintsCollected();
        SaveLivesLeft();
    }

    private async void SaveStartEndTimeToDatabase()
    {
        //getting gameStartTime
        string startTimeString = PlayerPrefs.GetString("gameStartTime"); 
        Debug.Log(startTimeString);
        startTimeString = startTimeString.Substring(0, startTimeString.Length-3);

        string[] timeSplit = startTimeString.Split(' ');
        if (timeSplit[0].Substring(0,2).Contains("/"))
        {
            startTimeString = startTimeString.Insert(0, "0");
        }
        if (timeSplit[1].Substring(0,2).Contains(":"))
        {
            startTimeString = startTimeString.Insert(11, "0");
        }
        DateTime gameStartTime = DateTime.ParseExact(startTimeString, "MM/dd/yyyy HH:mm:ss", null);
        
        var result = _gameEndTime.Subtract(gameStartTime).TotalMinutes/1000;
        
        var document = new BsonDocument()
        {
            {"totalPlayTime",result }
        };
        await _timingCollection.InsertOneAsync(document);
    }

    private async void SaveHintsCollected()
    {
        var document = new BsonDocument()
        {
            {"registryTime", PlayerPrefs.GetString("gameEndTime")},
            {"hintsCollected", PlayerPrefs.GetInt("hintsCollected")}
        };
        await _hintsCollection.InsertOneAsync(document);
    }

    private async void SaveLivesLeft()
    {
        var document = new BsonDocument()
        {
            {"registryTime", PlayerPrefs.GetString("gameEndTime")},
            {"livesLeft", PlayerPrefs.GetInt("livesLeft")}
        };
        await _livesCollection.InsertOneAsync(document);
    }
}
