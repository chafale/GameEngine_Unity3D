using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScript13 : MonoBehaviour
{
    public static int goldIndex;
    public static int currGoldIndex;

    public static string [][] hint_array = new string[][] {
      new string[] {"What has words, but never speaks?","This thing has a cover, But it is not a bed, It has many pages and is something that’s read ","A spine, no knees, Full of stories, You will find these, In libraries","It has spine, but no bones"},
      new string[] {"A hand without flesh and nothing can i hold my grip cannot be used until i am sold. What am I?","It has a thumb and four fingers, but is not a hand","Surgeons, skiers, thieves and boxers all wear me for different reasons","Used in winter to keep your hands warm"},
      new string[] {"Although this item is never half, It can sometimes be a quarter. If you come across a wishing well, You might throw it in the water? ","What has a head and a tail but no body I am NOT a snake ?","Surgeons, skiers, thieves and boxers all wear me for different reasons","I have two Faces but can bear only one"},
      new string[] {"If two’s company, and three’s a crowd, what are four plus five?","Do math 3+3+3","Highest single digit number","Greater than eight but smaller than ten"},
      new string[] {"I turn once, what is out will not get in. I turn again, what is in will not get out. What am I?","To open a door you can knock or use this item to unlock","1/3rd of the Turkey from the end"}
};

    [SerializeField] public static TextMeshProUGUI goldText;

    public static string[] goldList;

    public static void assign_values(){
        goldList = hint_array[GameManager13.index];
        // Debug.Log(goldIndex);
        // Debug.Log(goldList);
    }

    public static goldScript13 goldObj;
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
