using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mg = GameManager;
using gs = goldScript;
using mapgen = MapGenerator;
using gamsta = gameStatus;
using pl = Player;

public class Destroy : MonoBehaviour
{
    public int check;
    public static Destroy destroyObj;

    void Awake()
    {
        destroyObj = this;
    }

    void OnCollisionEnter(Collision collide) {
        
        GameObject obj1 = this.gameObject;
        GameObject collion_obj = collide.gameObject;

        if(obj1.tag=="blade"){
          if(collion_obj.tag=="Player"){
            Debug.Log("DIED HEREEEEEEE");
            Camera.GameEnd();
            Player.body.isKinematic = true;
          }
          return;
        }

        if(collion_obj.tag=="Player"){
            string collided_letter = gameObject.tag;
            Debug.Log("Collided with letter : " + collided_letter);
            Destroy(gameObject);
            char inputLetter = char.Parse(collided_letter);
            int c = 0;

            // Autofill the first uncaught character if letter = $
            if(inputLetter == '$')
            {
                // Analytics : Autofill Power-up capture
                PlayerPrefs.SetInt("autofillPowerUp", PlayerPrefs.GetInt("autofillPowerUp") + 1);
                
                char solved='a';
                for(int i=0;i<mg.letterHolderList.Count;i++)
                {
                    if(mg.letterHolderList[i].text == '_'.ToString())
                    {
                        gs.goldObj.updateHint(i+1);
                        mg.letterHolderList[i].text  = mg.solvedList[i].ToString();
                        solved = mg.solvedList[i];
                        var index = mapgen.displayCharacter.FindIndex(i => i.tag == gameObject.tag);
                        if (index >= 0) {
                         mapgen.displayCharacter.RemoveAt(index);
                        }
                        var index1 = mapgen.correctCharacters.FindIndex(i => i.tag == gameObject.tag);
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
                        var index = mapgen.displayCharacter.FindIndex(i => i.tag == gameObject.tag);
                        if (index >= 0) {
                         mapgen.displayCharacter.RemoveAt(index);
                        }
                        var index1 = mapgen.correctCharacters.FindIndex(i => i.tag == gameObject.tag);
                        if (index1 >= 0) {
                         mapgen.correctCharacters.RemoveAt(index1);
                        }
                        c=1;
                    }
                }

            }
            // Speed up player if letter = @
            else if(inputLetter=='@')
            {
                pl.playerSpeed+=3;
                gs.goldObj.updateHint(101);
                
                // Analytics : Speed Power-up capture
                PlayerPrefs.SetInt("speedPowerUp", PlayerPrefs.GetInt("speedPowerUp") + 1);
            }
            // Hint PopUp if letter = *
            else if(inputLetter=='*')
            {
                mg.hints-=1;
                
                // Analytics : Hints capture
                PlayerPrefs.SetInt("hintsCollected",PlayerPrefs.GetInt("hintsCollected") + 1);
                
                gs.goldIndex+=1;
                if(gs.goldIndex<=2)
                {
                    mg.gamag.updateGameHint();

                }
                gs.goldObj.updateHint(100);
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
                        }
                        // Debug.Log(collided_letter + " " + mapgen.correctCharacters.Count);
                        // for (int k = 0;k < mapgen.correctCharacters.Count;k++)
                        //  {
                        //    Debug.Log("Sanya "+mapgen.correctCharacters[k].tag);
                        //  }
                        c=1;
                    }
                }
                if(c == 0){
                    LivesScript.lives -= 1;
                    
                    // Analytics : LivesLeft capture
                    PlayerPrefs.SetInt("livesLeft", LivesScript.lives);
                    
                    if(LivesScript.lives == 0){
                        PlayerPrefs.SetInt("livesLeft", 0);
                        gamsta.gameStatusObj.updateStatus();
                        Debug.Log("The correct word was" + mg.correct_word);
                        Camera.GameEnd();
                        Player.body.isKinematic = true;
                    }
                }
            }
            check=0;
            // Check if all blanks are filled
            for (int i = 0; i < mg.solvedList.Count; i++)
            {
                char[] holder = mg.letterHolderList[i].text.ToCharArray();
                if(mg.solvedList[i] != holder[0]){
                    check = 1;
                    break;
                }
                if(i==mg.solvedList.Count-1)
                {
                    gamsta.gameStatusObj.updateStatus();
                }
            }
            if(check==0){
              Camera.GameEnd();
              Player.body.isKinematic = true;
            }
        }
        else{
          Debug.Log("Letter collided with letter");
          Destroy(gameObject);
        }
    }
}
