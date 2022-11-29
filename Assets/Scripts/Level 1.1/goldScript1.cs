using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScript1 : MonoBehaviour
{
    public static int goldIndex;
    public static int currGoldIndex;

    public static string [][] hint_array = new string[][] {
                                                new string[] {"Forward I am heavy, backwards I am not. What am I?","Answer is in the question","Measurement unit","What is 2000 pounds?"},
                                                new string[] {"What has to be broken before you can use it?","I give you strength","I am made up of only 2 colors","My end product has multiple shapes"},
                                                new string[] {"What goes up but never comes down.What am I?","•	It increases once a year !","You should never ask woman about it?","Which three letters change a girl into a woman?"},
};

    [SerializeField] public static TextMeshProUGUI goldText;

    public static string[] goldList;

    public static void assign_values(){
        goldList = hint_array[GameManager1.index];
        // Debug.Log(goldIndex);
        // Debug.Log(goldList);
    }

    public static goldScript1 goldObj;
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
