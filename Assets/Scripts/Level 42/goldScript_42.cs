using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScript_42 : MonoBehaviour
{
    public static int goldIndex;
    public static int currGoldIndex;

    public static string [][] hint_array = new string[][] {
                                                new string[] {"The more you take, the more you leave behind. What am I?","It comes in various sizes","Also has various patterns","Most observed by detectives"},
                                                new string[] {"What is black when you buy it, red when you use it, and gray when you throw it away?","Often comes in small pieces","To use it you burn it","Rare earth resource"},
                                                new string[] {"Poor people have it. Rich people need it. If you eat it, you will eventually die. What is it?","It is a *thing*","What do you eat while you sleep","What do you have if you lose everything you have"},
                                                new string[] {"What can you break, even if you never pick it up or touch it?","Other might get hurt if you break me","Word of honor","I am often asked before sharing secrets"},
                                                new string[] {"What is light as a feather, yet no man can hold it for very long?","You can not touch it","You can feel it","You need it for survival"},
                                                new string[] {"The more of this there is, the less you see. What is it?","This comes every day","Sight out","Most of us need this to sleep"},
                                                new string[] {"What is so fragile that saying its name breaks it?","You gain peace ","It is not an object","Meditation room"}
                                                        };

    [SerializeField] public static TextMeshProUGUI goldText;

    public static string[] goldList;

    public static void assign_values(){
        goldList = hint_array[GameManager_42.index];
    }

    public static goldScript_42 goldObj;
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
