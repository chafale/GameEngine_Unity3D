using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScriptEndless : MonoBehaviour
{
    public static int goldIndex;

    public static string [][] hint_array = new string[][] {
                                                new string[] {"Forward I am heavy, backwards I am not. What am I?","Answer is in the question","Measurement unit","What is 2000 pounds?"},
                                                new string[] {"What has to be broken before you can use it?","I give you strength","I am made up of only 2 colors","My end product has multiple shapes"},
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
												new string[] {"I turn once, what is out will not get in. I turn again, what is in will not get out. What am I?","To open a door you can knock or use this item to unlock","1/3rd of the Turkey from the end"},
                        new string[] {"I am tall when I am young, and I am short when I am old. What am I?","I am the light of your darkness","You blow me on a special day","I melt on heat"},
                        new string[] {"What is always in front of you but can not be seen?","You are sometimes worried about me","I am unpredictable","Only Dr.Strange can see me"},
                        new string[] {"What word is pronounced the same if you take away four of its five letters?","You are in this when you call customer care","Can be broken if you know someone in this","You often stand in this"},
                        new string[] {"I have many keys but can’t open a single door","You have to learn to be able to use me","You can have your career built around me","I sound on touch"},
                        new string[] {"They come at night without being called ","We are lost in the day without being stolen","You see me daily","You are ONE ;)"},
                        new string[] {"What has hands but cannot clap","The entity insude me changes every second","I point without fingers","Without arms I strike, Without feet I run"},
                        new string[] {"I can fly but have no wings. What am I?", "I can cry but I have no eyes", "Wherever I go, darkness follows me","I sometimes play with thunder" },
                        new string[] {"The man who makes it doesn’t use it","The man who buys it doesn’t need it","The man who uses it doesn’t know it.","The cave I sleep in fits me well.Where am I?"},
                        new string[] {"I don't have eyes, but once I did see","Once I had thoughts, but now I'm white and empty.","I hold the smartest organ of the body","I am often used on Halloween"},
                        new string[] {"It can be cracked","It can be made","It can be told","It can be played","I am usually funny"},
                        new string[] {"I have no life, but I can die, what am I?", "I can be recharged", "I am used in toys", "I am made of lithium"},
                        new string[] {"When the water comes down, when it rains, I go up. What am I?", "I come in different sizes and colors", "I can also protect you from the sun","Some people prefer a raincoat over of me :("},
                        new string[] {"I never ask questions, but I am always answered. What am I?", "I make a sound when I am called", "People use me before entering a house", "Ding Dong!"},
                        new string[] {"The poor have me; the rich need me. Eat me and you will die. What am I?", "When you close your eyes you see?", "I am the opposite of everything", "____ is permanent"},
                        new string[] {" What word contains all of the twenty-six letters?", "Kids learn me when they first go to school", "Every word is made out of me", "I can be learned as a song"},
                        new string[] {"The more of this there is, the less you see. What is it?", "You are surrounded by me in a cave", "Some people fear me", "I am present at night"},
                        new string[] {"What is 3/7th chicken, 2/3th cat and 2/4th goat?","Do math of the words","The letters you have to collect are in the question","I am a famous city"},
                        new string[] {"I follow you all the time and copy your every move, but you can’t touch me or catch me. What am I?","I am as big as you are and yet do not weigh anything?", "I can only live where there is light, but I die if the light shines on me.", "I nearly perish after the midday sun."},
                        new string[] {"What is so fragile that saying its name breaks it?", "I am there when you are quiet but I disappear when you speak", "I am the opposite of noise", "I am present in a library"},
                        new string[] {"What building has the most stories?", "I contain a lot of books", "People come here to study", "Preferred to be a silent zone"},
                        new string[] {"The more you take, the more you leave behind. What am I?","It comes in various sizes","Also has various patterns","Most observed by detectives"},
                        new string[] {"What is black when you buy it, red when you use it, and gray when you throw it away?","Often comes in small pieces","To use it you burn it","Rare earth resource"},
                        new string[] {"Before Mount Everest was discovered, what was the highest mountain on Earth?","Read the question again","You can not change what it is","Think logically"},
                        new string[] {"Poor people have it. Rich people need it. If you eat it, you will eventually die. What is it?","It is a *thing*","What do you eat while you sleep","What do you have if you lose everything you have"},
                        new string[] {"What can you break, even if you never pick it up or touch it?","Other might get hurt if you break me","Word of honor","I am often asked before sharing secrets"},
                        new string[] {"What is light as a feather, yet no man can hold it for very long?","You can not touch it","You can feel it","You need it for survival"},
                        new string[] {"The more of this there is, the less you see. What is it?","This comes every day","Sight out","Most of us need this to sleep"},
                        new string[] {"What is so fragile that saying its name breaks it?","You gain peace ","It is not an object","Meditation room"}                  
  };

    [SerializeField] public static TextMeshProUGUI goldText;

    public static string[] goldList;

    public static void assign_values(){
        goldList = hint_array[GameManagerEndless.index];
        // Debug.Log(goldIndex);
        // Debug.Log(goldList);
    }

    public static goldScriptEndless goldObj;
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
