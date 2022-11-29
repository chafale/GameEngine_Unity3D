using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScript12 : MonoBehaviour
{
    public static int goldIndex;
    public static int currGoldIndex;

    public static string [][] hint_array = new string[][] {
                                                new string[] {"I have branches, but no fruit, trunk or leaves. What am I? ","People create account but am not any social media app","Money heist","River has two of me!!"},
                                                new string[] {"What can’t talk but will reply when spoken to?","You've heard me before, yet you hear me again, Then I die 'til you call me again.","It repeat only the last word you say. The more I repeat, the softer I got. ","It speaks without a mouth and hear without ears, has no body, but come alive with wind."},
                                                new string[] {"I am invisible, weigh nothing, and if you put me in a barrel, it will become lighter. What am I?","It gets bigger when more is taken away","Pants pocket is empty, but there’s still something in it","Remove the W from whole to score"},
                                                new string[] {"It belongs to you, but other people use it more than you do. What is it? ","How do people address you","People call you by first, professional call you by last and parents when angry calls by middle","Always in the first line of myself"},
                                                new string[] {"Without fingers, I point, without arms, I strike, without feet, I run. What am I?","It has hands, but can’t clap","Do you have time for me?","It has a face that does not frown and hands that do not wave. I do not walk but move around"},
};

    [SerializeField] public static TextMeshProUGUI goldText;

    public static string[] goldList;

    public static void assign_values(){
        goldList = hint_array[GameManager12.index];
        // Debug.Log(goldIndex);
        // Debug.Log(goldList);
    }

    public static goldScript12 goldObj;
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
            else{
                goldText.text = "Autofill Power up Collected !!";
            }
            StartCoroutine(SetCountText());
        }
    }
}
