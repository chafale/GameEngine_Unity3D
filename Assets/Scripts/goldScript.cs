using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScript : MonoBehaviour
{
    public static int goldIndex;

    public static string [][] hint_array = new string[][] {
                                                new string[] {"Animal","Loyal","Pet"},
                                                new string[] {"Animal","Huge","Grey"},
                                                new string[] {"Drink","Caffeine","Starbucks"},
                                                new string[] {"Scientist","Gravity","Motion"}
                                                        };

    [SerializeField] public static TextMeshProUGUI goldText;

    public static string[] goldList;

    public static void assign_values(){
        goldIndex = 0;
        goldList = hint_array[GameManager.index];
        Debug.Log(goldIndex);
        Debug.Log(goldList);
    }

    public static goldScript goldObj;
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
        if(goldIndex >= 3)
        {
            goldText.text = "No More Hints";
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
            else{
                goldText.text = "Autofill Power up Collected !! Blank "+ temp.ToString() + " is filled";
            }
            StartCoroutine(SetCountText());
        }
    }
}
