using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_InputField letterInput;

    public string[] wordList;
    public List<char> solvedList = new List<char>();

    public List<TMP_Text> letterHolderList = new List<TMP_Text>();
    public GameObject letterPrefab;
    public Transform letterHolder;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    void Initialize(){
        int index = Random.Range(0, wordList.Length);
        string tempWord = wordList[index];

        string[] splittedWord = tempWord.Split(' ', tempWord.Length);
        char[] splitWord = tempWord.ToCharArray();
        Debug.Log(splitWord[0]);
        foreach (char letter in splitWord){
            solvedList.Add(letter);
        }

        for (int i = 0; i < solvedList.Count; i++)
        {
            GameObject temp = Instantiate(letterPrefab, letterHolder, false);
            letterHolderList.Add(temp.GetComponent<TMP_Text>());

        }
    }

    public void InputButton(){
        char inputLetter = char.Parse(letterInput.text);
        Debug.Log(inputLetter);
        if (inputLetter == '\0'){
            return;
        }
        CheckLetter(inputLetter);
        letterInput.text = "";
    }

    void CheckLetter(char letter){
        for (int i = 0; i < solvedList.Count; i++)
        {   
            if(solvedList[i] == letter){
                letterHolderList[i].text = letter.ToString();
            }
        }
    }
}
