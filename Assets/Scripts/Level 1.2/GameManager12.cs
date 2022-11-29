using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using gs = goldScript12;
using mg = MapGenerator12;

public class GameManager12 : MonoBehaviour
{
    //public  static string[] wordList = {"DOG"};
    public  static string[] wordList = {"BANK","ECHO","HOLE","NAME","CLOCK"};
    // public  static string[] hintList = {"Most Adopted Pet"};
    public static List<char> solvedList = new List<char>();
    public  static List<TMP_Text> letterHolderList = new List<TMP_Text>();
    public  GameObject letterPrefab;
    public  Transform letterHolder;
    public  TMP_Text hint;
    public  ScoringSystem instance;
    public static int hints;
    public static int index;
    public static string correct_word;

    public GameObject A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z;
    public static List<GameObject> chars = new List<GameObject>();

    public TMP_Text riddle;
    [SerializeField] GameObject scoreAnimPrefab;


    public  static List<TMP_Text> RiddleletterHolderList = new List<TMP_Text>();
    public  Transform RiddleletterHolder;
    public bool check = true;
    public TMP_Text RiddleCanvasriddle;
    public GameObject RiddleCanvas;
    public  GameObject L1Canvas;
    public int count = 0;
    public AudioSource HintAudioPlayer, PowerAudioPlayer, WinAudioPlayer, LoseAudioPlayer, CorrectLetterAudioPlayer, WrongLetterAudioPlayer;

    void Start(){
        mg.correctCharacters.Clear();
        chars.Clear();
        hints = 3;
        chars.AddRange(new List<GameObject> {A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z });
        index = Random.Range(0, wordList.Length);
        correct_word = wordList[index];
        Debug.Log("CORRECT WORD IS:" + correct_word);

        // Analytics : LevelName, wordLength
        PlayerPrefs.SetString("levelName", "Level 1");
        PlayerPrefs.SetInt("wordLength", correct_word.Length);

        gs.assign_values();

        // hint.text = hintList[index]
        // hint.text = "Hint: " + gs.goldList[gs.goldIndex].ToString();
        riddle.text = gs.goldList[0].ToString();
        RiddleCanvasriddle.text = gs.goldList[0].ToString();

        string tempWord = wordList[index];

        string[] splittedWord = tempWord.Split(' ', tempWord.Length);
        char[] splitWord = tempWord.ToCharArray();
        // Debug.Log(tempWord);
        foreach (char letter in splitWord){
            solvedList.Add(letter);
            foreach(GameObject letter_prefab in chars){
              char inputLetter = char.Parse(letter_prefab.tag);
              if(inputLetter == letter){
                    mg.correctCharacters.Add(letter_prefab);

              }
            }
        }

        for (int i = 0; i < tempWord.Length; i++)
        {
            GameObject temp = Instantiate(letterPrefab, letterHolder, false);
            TMP_Text tempText = temp.GetComponent<TMP_Text>();
            tempText.color = Color.black;
            letterHolderList.Add(tempText);
            GameObject temp1 = Instantiate(letterPrefab, RiddleletterHolder, false);
            RiddleletterHolderList.Add(temp1.GetComponent<TMP_Text>());
        }

    }

    // To call non static methods.
    public static GameManager12 gamag;
    internal static object displayCharacter;
    void Awake()
    {
        gamag = this;
    }

    public void Update(){
        if (check)
            Time.timeScale = 0;
        if(count == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Continue Bar was pressed");
            L1Canvas.SetActive(false);
            RiddleCanvas.SetActive(true);
            count++;
        }
        else if(count == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Continue Bar was pressed");
            RiddleCanvas.SetActive(false);
            Time.timeScale = 1;
            check = false;
            count++;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (gs.goldIndex > 0)
            {
                gs.currGoldIndex = (gs.currGoldIndex % gs.goldIndex) + 1;
                hint.text = "Hint: " + gs.goldList[gs.currGoldIndex].ToString();
            }
        }
}

    public void updateGameHint()
    {
        hint.text = "Hint: " + gs.goldList[gs.goldIndex].ToString();
        showScoreAnim("1000000");
    }
    public void showScoreAnim(string text){
        Debug.Log("Anime Function Here");
        if(scoreAnimPrefab)
        {
            GameObject prefab = Instantiate(scoreAnimPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TMP_Text>().text = text;
            Debug.Log("Anime Here");
        }
    }

}
