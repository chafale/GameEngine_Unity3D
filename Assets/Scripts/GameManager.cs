using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using gs = goldScript;

public class GameManager : MonoBehaviour
{
    public  static string[] wordList = {"DOG"};
    // public  static string[] hintList = {"Most Adopted Pet"};
    public static List<char> solvedList = new List<char>();

    public  static List<TMP_Text> letterHolderList = new List<TMP_Text>();
    public  GameObject letterPrefab;
    public  Transform letterHolder;
    public  TMP_Text hint;



    void Start(){
        int index = Random.Range(0, wordList.Length);
        // hint.text = hintList[index]
        hint.text = "Hint: " + gs.goldList[gs.goldIndex].ToString();
        string tempWord = wordList[index];

        string[] splittedWord = tempWord.Split(' ', tempWord.Length);
        char[] splitWord = tempWord.ToCharArray();
        // Debug.Log(splitWord[0]);
        foreach (char letter in splitWord){
            solvedList.Add(letter);
        }

        for (int i = 0; i < 3; i++)
        {
            GameObject temp = Instantiate(letterPrefab, letterHolder, false);
            letterHolderList.Add(temp.GetComponent<TMP_Text>());
        }
    }

    // To call non static methods.
    public static GameManager gamag;
    void Awake()
    {
        gamag = this;
    }

    public void updateGameHint()
    {
        hint.text = "Hint: " + gs.goldList[gs.goldIndex].ToString();
    }

}
