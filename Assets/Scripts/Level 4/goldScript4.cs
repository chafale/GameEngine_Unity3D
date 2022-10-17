using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScript4 : MonoBehaviour
{
    public static int goldIndex;

    public static string [][] hint_array = new string[][] {
                                                new string[] {"Forward I am heavy, backwards I am not. What am I?","Answer is in the question","Measurement unit","What is 2000 pounds?"},
                                                new string[] {"What has to be broken before you can use it?","I give you strength","I am made up of only 2 colors","My end product has multiple shapes"},
                                                new string[] {"I am tall when I am young, and I am short when I am old. What am I?","I am the light of your darkness","You blow me on a special day","I melt on heat"},
                                                new string[] {"What is always in front of you but can not be seen?","You are sometimes worried about me","I am unpredictable","Only Dr.Strange can see me"},
                                                new string[] {"What can you break, even if you never pick it up or touch it?","Other might get hurt if you break me","Word of honor","I am often asked before sharing secrets"},
                                                new string[] {"I have branches, but no fruit, trunk or leaves. What am I?","You can see me in most of the streets","You can not live without me","You save your valuables with me"},
                                                new string[] {"What is 3/7th chicken, 2/3th cat and 2/4th goat?","Do math of the words","The letters you have to collect are in the question","I am a famous city"},
                                                new string[] {"What word is pronounced the same if you take away four of its five letters?","You are in this when you call customer care","Can be broken if you know someone in this","You often stand in this"},
                                                new string[] {"What is so fragile that saying its name breaks it?","You gain peace ","It is not an object","Meditation room"},
                                                new string[] {"I have many keys but can’t open a single door","You have to learn to be able to use me","You can have your career built around me","I sound on touch"}
                                                        };

    [SerializeField] public static TextMeshProUGUI goldText;

    public static string[] goldList;

    public static void assign_values(){
        goldList = hint_array[GameManager4.index];
        // Debug.Log(goldIndex);
        // Debug.Log(goldList);
    }

    public static goldScript4 goldObj;
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
            if(temp==100)
            {
                goldText.text = "New Hint: " + goldList[goldIndex].ToString();
            }
            else if(temp==101){
                goldText.text = "Speed Power up Collected !!";
            }
            else if(temp==102){
                goldText.text = "Health Power up Collected !!";
            }
            else if(temp==103){
                 goldText.text = "Split Colour Power up Collected !!";
            }
            else
            {
                goldText.text = "Autofill Power up Collected !!";
            }
            StartCoroutine(SetCountText());
        }
    }
}
