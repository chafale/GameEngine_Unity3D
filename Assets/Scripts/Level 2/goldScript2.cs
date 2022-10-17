using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScript2 : MonoBehaviour
{
    public static int goldIndex;

    public static string [][] hint_array = new string[][] {
                                                new string[] {"I am tall when I am young, and I am short when I am old. What am I?","I am the light of your darkness","You blow me on a special day","I melt on heat"},
                                                new string[] {"What is always in front of you but can not be seen?","You are sometimes worried about me","I am unpredictable","Only Dr.Strange can see me"},
                                                new string[] {"What word is pronounced the same if you take away four of its five letters?","You are in this when you call customer care","Can be broken if you know someone in this","You often stand in this"},
                                                new string[] {"I have many keys but can’t open a single door","You have to learn to be able to use me","You can have your career built around me","I sound on touch"},
                                                new string[] {"They come at night without being called ","We are lost in the day without being stolen","You see me daily","You are ONE ;)"},
                                                new string[] {"What has hands but cannot clap","The entity insude me changes every second","I point without fingers","Without arms I strike, Without feet I run"},
                                                new string[] {"I can fly but have no wings. What am I?", "I can cry but I have no eyes", "Wherever I go, darkness follows me","I sometimes play with thunder" },
                                                new string[] {"The man who makes it doesn’t use it","The man who buys it doesn’t need it","The man who uses it doesn’t know it.","The cave I sleep in fits me well.Where am I?"},
                                                new string[] {"I don't have eyes, but once I did see","Once I had thoughts, but now I'm white and empty.","I hold the smartest organ of the body","I am often used on Halloween"},
                                                new string[] {"It can be cracked","It can be made","It can be told","It can be played","I am usually funny"} };
 
    [SerializeField] public static TextMeshProUGUI goldText;

    public static string[] goldList;

    public static void assign_values(){
        goldList = hint_array[GameManager2.index];
        // Debug.Log(goldIndex);
        // Debug.Log(goldList);
    }

    public static goldScript2 goldObj;
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
