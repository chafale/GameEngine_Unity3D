using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goldScript3 : MonoBehaviour
{
    public static int goldIndex;

    public static string [][] hint_array = new string[][] {
                                                //BATTERY
                                                new string[] {"I have no life, but I can die, what am I?", "I can be recharged", "I am used in toys", "I am made of lithium"},
                                                //UMBRELLA
                                                new string[] {"When the water comes down, when it rains, I go up. What am I?", "I come in different sizes and colors", "I can also protect you from the sun","Some people prefer a raincoat over of me :("},
                                                //DOORBELL
                                                new string[] {"I never ask questions, but I am always answered. What am I?", "I make a sound when I am called", "People use me before entering a house", "Ding Dong!"},
                                                //NOTHING
                                                new string[] {"The poor have me; the rich need me. Eat me and you will die. What am I?", "When you close your eyes you see?", "I am the opposite of everything", "____ is permanent"},
                                                //ALPHABET
                                                new string[] {" What word contains all of the twenty-six letters?", "Kids learn me when they first go to school", "Every word is made out of me", "I can be learned as a song"},
                                                //DARKNESS
                                                new string[] {"The more of this there is, the less you see. What is it?", "You are surrounded by me in a cave", "Some people fear me", "I am present at night"},
                                                //CHICAGO
                                                new string[] {"What is 3/7th chicken, 2/3th cat and 2/4th goat?","Do math of the words","The letters you have to collect are in the question","I am a famous city"},
                                                //SHADOW
                                                new string[] {"I follow you all the time and copy your every move, but you can’t touch me or catch me. What am I?","I am as big as you are and yet do not weigh anything?", "I can only live where there is light, but I die if the light shines on me.", "I nearly perish after the midday sun."},
                                                //SILENCE
                                                new string[] {"What is so fragile that saying its name breaks it?", "I am there when you are quiet but I disappear when you speak", "I am the opposite of noise", "I am present in a library"},
                                                //LIBRARY
                                                new string[] {"What building has the most stories?", "I contain a lot of books", "People come here to study", "Preferred to be a silent zone"}
                                                        };

    [SerializeField] public static TextMeshProUGUI goldText;

    public static string[] goldList;

    public static void assign_values(){
        goldList = hint_array[GameManager3.index];
        // Debug.Log(goldIndex);
        // Debug.Log(goldList);
    }

    public static goldScript3 goldObj;
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
