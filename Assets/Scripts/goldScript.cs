using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static int goldIndex;

    public static string [][] hint_array = new string[][] {
                                                new string[] {"Animal","Loyal","Pet"},
                                                new string[] {"Animal","Huge","Grey"},
                                                new string[] {"Drink","Caffeine","Starbucks"},
                                                new string[] {"Scientist","Gravity","Motion"}
                                                        };

    [SerializeField] TextMeshProUGUI goldText;

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

    // Update is called once per frame
    public void updateHint()
    {
        if(goldIndex >= 3)
        {
            goldText.text = "No More Hints";
        }
        else
        {
            goldText.text = "New Hint: " + goldList[goldIndex].ToString();
        }
    }
}
