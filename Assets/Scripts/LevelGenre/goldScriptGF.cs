using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScriptGF : MonoBehaviour
{
    public static int goldIndex;

    public static string [][] hint_array = new string[][] {
                                                new string[] {"Guess the first three alphabets of an uncommonly used language","Greek Alphabets"},
                                                new string[] {"Things with 4 legs present in every house","They are sed everyday"},
                                                // new string[] {"Before Mount Everest was discovered, what was the highest mountain on Earth?","Read the question again","You can not change what it is","Think logically"},
                                                };

    [SerializeField] public static TextMeshProUGUI goldText;

    public static string[] goldList;

    public static void assign_values(){
        goldList = hint_array[GameManagerGF.index];
        // Debug.Log(goldIndex);
        // Debug.Log(goldList);
    }

    public static goldScriptGF goldObj;
    void Awake()
    {
        goldObj = this;
    }
    void Start()
    {
        goldText = GetComponent<TMPro.TextMeshProUGUI>();
    }

    IEnumerator SetCountText()
    {
        Debug.Log("hi inside");
        yield return new WaitForSeconds(2);
        goldText.text = "";
    }


    // Update is called once per frame
    public void updateHint(int temp)
    {
        if(goldIndex > 3)
        {
            goldText.text = "";
        }
        else
        {
            if(temp == 100)
            {
                goldText.text = "New Hint: " + goldList[goldIndex].ToString();
            }
            else if(temp == 101){
                goldText.text = "Speed Power up Collected!!";
            }
            else if(temp == 102){
                goldText.text = "Health Power up Collected!!";
            }
            else if(temp == 103){
                goldText.text = "Split Color Power up Collected!!";
            }
            else{
                goldText.text = "Autofill Power up Collected!!";
            }
            StartCoroutine(SetCountText());
        }
    }
}
