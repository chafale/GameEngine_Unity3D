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
<<<<<<< HEAD

                                                 new string[] {"What goes up but never comes down.What am I?","•	It increases once a year !","You should never ask woman about it?","Which three letters change a girl into a woman?"},
                                                 new string[] {"I have branches, but no fruit, trunk or leaves. What am I? ","People create account but am not any social media app","Money heist","River has two of me!!"},
                                                 new string[] {"What can’t talk but will reply when spoken to?","You've heard me before, yet you hear me again, Then I die 'til you call me again.","It repeat only the last word you say. The more I repeat, the softer I got. ","It speaks without a mouth and hear without ears, has no body, but come alive with wind."},
                                                 new string[] {"I am invisible, weigh nothing, and if you put me in a barrel, it will become lighter. What am I?","It gets bigger when more is taken away","Pants pocket is empty, but there’s still something in it","Remove the W from whole to score"},
                                                 new string[] {"It belongs to you, but other people use it more than you do. What is it? ","How do people address you","People call you by first, professional call you by last and parents when angry calls by middle","Always in the first line of myself"},
                                                 new string[] {"Without fingers, I point, without arms, I strike, without feet, I run. What am I?","It has hands, but can’t clap","Do you have time for me?","It has a face that does not frown and hands that do not wave. I do not walk but move around"},
                                                 new string[] {"What has words, but never speaks?","This thing has a cover, But it is not a bed, It has many pages and is something that’s read ","A spine, no knees, Full of stories, You will find these, In libraries","It has spine, but no bones"},
                                                 new string[] {"A hand without flesh and nothing can i hold my grip cannot be used until i am sold. What am I?","It has a thumb and four fingers, but is not a hand","Surgeons, skiers, thieves and boxers all wear me for different reasons","Used in winter to keep your hands warm"},
												new string[] {"Although this item is never half, It can sometimes be a quarter. If you come across a wishing well, You might throw it in the water? ","What has a head and a tail but no body I am NOT a snake ?","Surgeons, skiers, thieves and boxers all wear me for different reasons","I have two Faces but can bear only one"},
												 new string[] {"If two’s company, and three’s a crowd, what are four plus five?","Do math 3+3+3","Highest single digit number","Greater than eight but smaller than ten"},
												 new string[] {"I turn once, what is out will not get in. I turn again, what is in will not get out. What am I?","To open a door you can knock or use this item to unlock","1/3rd of the Turkey from the end"}


=======
                                                new string[] {"What goes up but never comes down.What am I?","•	It increases once a year !","You should never ask woman about it?","Which three letters change a girl into a woman?"},
                                                new string[] {"I have branches, but no fruit, trunk or leaves. What am I? ","People create account but am not any social media app","Money heist","River has two of me!!"},
                                                new string[] {"What can’t talk but will reply when spoken to?","You've heard me before, yet you hear me again, Then I die 'til you call me again.","It repeat only the last word you say. The more I repeat, the softer I got. ","It speaks without a mouth and hear without ears, has no body, but come alive with wind."},
                                                new string[] {"I am invisible, weigh nothing, and if you put me in a barrel, it will become lighter. What am I?","It gets bigger when more is taken away","Pants pocket is empty, but there’s still something in it","Remove the W from whole to score"},
                                                new string[] {"It belongs to you, but other people use it more than you do. What is it? ","How do people address you","People call you by first, professional call you by last and parents when angry calls by middle","Always in the first line of myself"},
                                                new string[] {"Without fingers, I point, without arms, I strike, without feet, I run. What am I?","It has hands, but can’t clap","Do you have time for me?","It has a face that does not frown and hands that do not wave. I do not walk but move around"},
                                                new string[] {"What has words, but never speaks?","This thing has a cover, But it is not a bed, It has many pages and is something that’s read ","A spine, no knees, Full of stories, You will find these, In libraries","It has spine, but no bones"},
                                                new string[] {"A hand without flesh and nothing can i hold my grip cannot be used until i am sold. What am I?","It has a thumb and four fingers, but is not a hand","Surgeons, skiers, thieves and boxers all wear me for different reasons","Used in winter to keep your hands warm"},
												new string[] {"Although this item is never half, It can sometimes be a quarter. If you come across a wishing well, You might throw it in the water? ","What has a head and a tail but no body I am NOT a snake ?","Surgeons, skiers, thieves and boxers all wear me for different reasons","I have two Faces but can bear only one"},
												new string[] {"If two’s company, and three’s a crowd, what are four plus five?","Do math 3+3+3","Highest single digit number","Greater than eight but smaller than ten"},
												new string[] {"I turn once, what is out will not get in. I turn again, what is in will not get out. What am I?","To open a door you can knock or use this item to unlock","1/3rd of the Turkey from the end"}
>>>>>>> ef4f3aa9 (hints error fix)
  };

    [SerializeField] public static TextMeshProUGUI goldText;

    public static string[] goldList;

    public static void assign_values(){
          Debug.Log("In assign Values");
        Debug.Log(GameManager1.index);
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
