﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using mg = GameManager;
using mapgen = MapGenerator;
using TMPro;

public class Camera : MonoBehaviour {

    public Player player;
    public GameObject Background;
    public static GameObject overReset;

    public GameObject Hintground;
     public static GameObject goldReset;
    // Use this for initialization
    void Start () {
        LivesScript.lives = 3;
        goldScript.goldIndex = 0;
        overReset = GameObject.Find("Background");
        overReset.SetActive(false);
        goldReset = GameObject.Find("Hintground");
        goldReset.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        if (!player.gameOver)
        {
            transform.position += new Vector3(5f * Time.deltaTime, 0, 0);
        }
        else
        {
            GameEnd();
        }
    }
    public static void GameEnd(){
        // GameObject.Find("Background").SetActive(true);
        mg.solvedList = new List<char>();
        mg.letterHolderList = new List<TMP_Text>();
        mg.chars = new List<GameObject>();
        mapgen.correctCharacters = new List<GameObject>();
        // mapgen.displayCharacter = new List<GameObject>();
        overReset.SetActive(true);
    }
    public void Reset()
    {
        Debug.Log("Reset");
        mg.solvedList = new List<char>();
        mg.letterHolderList = new List<TMP_Text>();
        mapgen.correctCharacters = new List<GameObject>();
        mapgen.displayCharacter = new List<GameObject>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void Pause()
    {
        Time.timeScale = 0;
        goldReset.SetActive(true);
    }
    public static void Resume()
    {
        Time.timeScale = 1;
        goldReset.SetActive(false);
    }
}
