using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using gs = goldScript;
using mg = MapGenerator;

public class GameManager : MonoBehaviour
{
    //public  static string[] wordList = {"DOG"};
    public  static string[] wordList = {"TON","EGG","CANDLE","FUTURE","PROMISE","BANK","CHICAGO","QUEUE","SILENCE","PIANO"};
    // public  static string[] hintList = {"Most Adopted Pet"};
    public static List<char> solvedList = new List<char>();

    public  static List<TMP_Text> letterHolderList = new List<TMP_Text>();
    public  GameObject letterPrefab;
    public  Transform letterHolder;
    public  TMP_Text hint;

    public static int hints;
    public static int index;

    public GameObject A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z;
    public static List<GameObject> chars = new List<GameObject>();

    public TMP_Text riddle;

    void Start(){
        mg.correctCharacters.Clear();
        chars.Clear();
        hints = 3;
        chars.AddRange(new List<GameObject> {A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z });
        index = Random.Range(0, wordList.Length);

        gs.assign_values();

        // hint.text = hintList[index]
        // hint.text = "Hint: " + gs.goldList[gs.goldIndex].ToString();
        riddle.text = gs.goldList[0].ToString();

        string tempWord = wordList[index];

        string[] splittedWord = tempWord.Split(' ', tempWord.Length);
        char[] splitWord = tempWord.ToCharArray();
        Debug.Log(tempWord);
        foreach (char letter in splitWord){
            solvedList.Add(letter);
            foreach(GameObject letter_prefab in chars){
              char inputLetter = char.Parse(letter_prefab.tag);
              if(inputLetter == letter){
                // Debug.Log("Ayush " + inputLetter);
                mg.correctCharacters.Add(letter_prefab);
              }
            }
        }

        for (int i = 0; i < tempWord.Length; i++)
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
