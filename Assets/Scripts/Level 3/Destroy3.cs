using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using mg = GameManager3;
using gs = goldScript3;
using mapgen = MapGenerator3;
using gamsta = gameStatus3;
using pl = Player;
using hb = HealthBar;

public class Destroy3 : MonoBehaviour
{
    public int check;
    public int goCheck;
    public static Destroy3 destroyObj;
    public Player player;
    public int gamescore = 0;
    [SerializeField] GameObject scoreAnimPrefab;
    public Canvas animeCanvas;
    public bool sc_correct = false;
    public bool sc_incorrect = false;



    void Awake()
    {
        destroyObj = this;
    }

    void OnCollisionEnter(Collision collide) {

        GameObject obj1 = this.gameObject;
        GameObject collion_obj = collide.gameObject;
        GameManager3 gameManager = GameObject.Find("GameManager").GetComponent<GameManager3>();

        // if(obj1.tag=="blade"){
        //   if(collion_obj.tag=="Player"){
        //     Debug.Log("DIED HEREEEEEEE");
        //     Camera.GameEnd();
        //     Player.body.isKinematic = true;
        //   }
        //   return;
        // }
        Debug.Log(collion_obj.tag);

        if(collion_obj.tag=="Player"){
            string collided_letter = gameObject.tag;
            Debug.Log("Collided with letter : " + collided_letter);

            Destroy(gameObject);
            char inputLetter = char.Parse(collided_letter);
            int c = 0;

            if(inputLetter=='~')
            {
                Debug.Log("In Invisible Mode");

            }
            // Health bar increase power up if letter = #
            if(inputLetter=='#')
            {
                // Analytics : Medical Kit Power-up
                PlayerPrefs.SetInt("medKitPowerUp", PlayerPrefs.GetInt("medKitPowerUp") + 1);

                if(hb.healthObj.slider.value<=75)
                {
                    gs.goldObj.updateHint(102);
                    FindObjectOfType<Player>().currentHealth+=25;
                    hb.healthObj.slider.value+=25f;
                    showScoreAnim("10000");
                }
            }
            // Autofill the first uncaught character if letter = $
            else if(inputLetter == '$')
            {
                // Analytics : Autofill Power-up capture
                PlayerPrefs.SetInt("autofillPowerUp", PlayerPrefs.GetInt("autofillPowerUp") + 1);

                // FindObjectOfType<Player>().TakeDamage(5);
                char solved='a';
                for(int i=0;i<mg.letterHolderList.Count;i++)
                {
                    if(mg.letterHolderList[i].text == '_'.ToString())
                    {
                        gs.goldObj.updateHint(i+1);
                        mg.letterHolderList[i].text  = mg.solvedList[i].ToString();
                        solved = mg.solvedList[i];
                        Debug.Log("solved " + solved);
                        var index = mapgen.displayCharacter.FindIndex(i => i.tag == solved.ToString());
                        if (index >= 0) {
                         mapgen.displayCharacter.RemoveAt(index);
                        }
                        var index1 = mapgen.correctCharacters.FindIndex(i => i.tag == solved.ToString());
                        if (index1 >= 0) {
                         mapgen.correctCharacters.RemoveAt(index1);
                        }
                        break;
                    }
                }

                for (int i = 0; i < mg.solvedList.Count; i++)
                {
                    if(mg.solvedList[i] == solved && mg.letterHolderList[i].text == '_'.ToString()){
                        mg.letterHolderList[i].text = solved.ToString();
                        var index = mapgen.displayCharacter.FindIndex(i => i.tag == solved.ToString());
                        if (index >= 0) {
                         mapgen.displayCharacter.RemoveAt(index);
                        }
                        var index1 = mapgen.correctCharacters.FindIndex(i => i.tag == solved.ToString());
                        if (index1 >= 0) {
                         mapgen.correctCharacters.RemoveAt(index1);
                        }
                    }
                }

            }
            // Speed up player if letter = @
            else if(inputLetter=='@')
            {
                // Analytics : Speed Power-up
                PlayerPrefs.SetInt("speedPowerUp",PlayerPrefs.GetInt("speedPowerUp") + 1);

                pl.playerSpeed+=3;
                gs.goldObj.updateHint(101);
                // FindObjectOfType<Player>().TakeDamage(5);
            }
            // Hint PopUp if letter = *
            else if(inputLetter=='*')
            {
                mg.hints-=1;

                // Analytics : hints
                PlayerPrefs.SetInt("hintsCollected",PlayerPrefs.GetInt("hintsCollected") + 1);

                gs.goldIndex+=1;
                gs.currGoldIndex = gs.goldIndex;
                if(gs.goldIndex<=3)
                {
                    mg.gamag.updateGameHint();

                }
                gs.goldObj.updateHint(100);
                // FindObjectOfType<Player>().TakeDamage(5);
                // Camera.Pause();
            }
            // Fill blanks
            else{
                for (int i = 0; i < mg.solvedList.Count; i++)
                {
                    if(mg.solvedList[i] == inputLetter){
                        Debug.Log("Ayush");
                        mg.letterHolderList[i].text = inputLetter.ToString();
                        var index = mapgen.displayCharacter.FindIndex(i => i.tag == gameObject.tag);
                        if (index >= 0) {
                         mapgen.displayCharacter.RemoveAt(index);
                        }
                        var index1 = mapgen.correctCharacters.FindIndex(i => i.tag == gameObject.tag);
                        if (index1 >= 0) {
                         mapgen.correctCharacters.RemoveAt(index1);
                         // incrementing score each time we have a correct letter
                         ScoringSystem.instance.AddPoint();
                         showScoreAnim("+10");
                        }
                        // Debug.Log(collided_letter + " " + mapgen.correctCharacters.Count);
                        // for (int k = 0;k < mapgen.correctCharacters.Count;k++)
                        //  {
                        //    Debug.Log("Sanya "+mapgen.correctCharacters[k].tag);
                        //  }
                        c=1;
                        sc_correct  = true;
                        FindObjectOfType<Player>().showScoreAnim(" +10 ",sc_correct);
                    }
                }

                for (int i = 0; i < mg.goList.Count; i++)
                {
                    if(mg.goList[i] == inputLetter){
                        gameManager.GoCanvas.SetActive(true);
                        mg.goHolderList[i].text = inputLetter.ToString();

                        var index = mapgen.goCharacters.FindIndex(i => i.tag == gameObject.tag);
                        if (index >= 0) {
                         mapgen.goCharacters.RemoveAt(index);
                        }

                        // var index = mapgen.displayCharacter.FindIndex(i => i.tag == gameObject.tag);
                        // if (index >= 0) {
                        //  mapgen.displayCharacter.RemoveAt(index);
                        // }
                        // var index1 = mapgen.correctCharacters.FindIndex(i => i.tag == gameObject.tag);
                        // if (index1 >= 0) {
                        //  mapgen.correctCharacters.RemoveAt(index1);
                        // }
                        // // Debug.Log(collided_letter + " " + mapgen.correctCharacters.Count);
                        // // for (int k = 0;k < mapgen.correctCharacters.Count;k++)
                        // //  {
                        // //    Debug.Log("Sanya "+mapgen.correctCharacters[k].tag);
                        // //  }
                        // c=1;
                        // sc_correct  = true;
                        // FindObjectOfType<Player>().showScoreAnim("+10",sc_correct);
                    }
                }

                if (c == 0)
                {
                    // LivesScript.lives -= 1;
                    // when health has decreased to zero
                    FindObjectOfType<Player>().TakeDamage(10);
                    sc_incorrect  = true;
                    FindObjectOfType<Player>().showScoreAnim("Wrong Letter: -10 ",sc_incorrect);
                    Debug.Log("Health decreased" + FindObjectOfType<Player>().currentHealth);
                    // gamsta.gameStatusObj.updateStatus();
                    if(FindObjectOfType<Player>().currentHealth<=0){
                      FindObjectOfType<Player>().gameOver = true;
                    }
                    PlayerPrefs.SetInt("highscore", gamescore);
                    // Debug.Log("The correct word was" + mg.correct_word);
                    // if(LivesScript.lives == 0){
                    //     PlayerPrefs.SetInt("livesLeft", 0);
                    //     Camera.GameEnd();
                    //     Player.body.isKinematic = true;
                    //     Debug.Log("I am lives here");
                    // }
                }
            }
            check=0;
            // Check if all blanks are filled
            for (int i = 0; i < mg.solvedList.Count; i++)
            {
                char[] holder = mg.letterHolderList[i].text.ToCharArray();
                if(mg.solvedList[i] != holder[0]){
                    Debug.Log("mg.solvedList[i] is not equal to holder[0]");
                    check = 1;
                    break;
                }
                //if (i == mg.solvedList.Count - 1)
                //{
                //    Debug.Log("solvedlist count -1");
                //    gamsta.gameStatusObj.updateStatus();
                //}
            }

            // GO CHECK

            goCheck = 0;
            for (int i = 0; i < mg.goList.Count; i++)
            {
                char[] holder = mg.goHolderList[i].text.ToCharArray();
                if(mg.goList[i] != holder[0]){
                    goCheck = 1;
                    break;

                }
            }
            if (goCheck == 0) {
                // Analytics : GO word complete
                foreach( TMP_Text g in mg.goHolderList){
                    Destroy(g.gameObject);
                }
                mg.goHolderList.Clear();
                for (int i = 0; i < 2; i++)
                {
                    GameObject temp = Instantiate(gameManager.letterPrefab, gameManager.goHolder, false);
                    TMP_Text tempText = temp.GetComponent<TMP_Text>();
                    tempText.color = Color.black;
                    tempText.fontSize = 60;
                    tempText.fontStyle = FontStyles.Bold;
                    mg.goHolderList.Add(tempText);
                }
                gameManager.goCollected = true;
                gameManager.goText.text = "Obstacles will be eliminated for some time";
                Debug.Log("gameMananger.goCollected in destroy: " + gameManager.goCollected);
                gameManager.GoPopup.SetActive(true);
                // Analytics : HEAL word complete
                PlayerPrefs.SetInt("goStatus", 1);
                // gameManager.goCollected = false;
                
            }
            

            if(check==0){
                // same as i == mg.solvedList.Count - 1
                Debug.Log("check ==0");
                // win message
                gamsta.gameStatusObj.updateStatus();
                Camera3.GameEnd();
                Player.body.isKinematic = true;
            }
        }
        else{
          Debug.Log("Letter collided with letter");
          Destroy(gameObject);
        }
    }

    public void showScoreAnim(string text){
        Debug.Log("Hellllooooo ichhaaaaaaa");
    }
}
