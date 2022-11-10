using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using tm = TutorialManager;
public class DestroyTutorial : MonoBehaviour
{
     public int check;
    void OnCollisionEnter(Collision collide) {
        //Debug.Log("objected collided");
        GameObject obj1 = this.gameObject;
        // Debug.Log("OBJ1 " + obj1.tag);
        GameObject collion_obj = collide.gameObject;
        // Debug.Log("collion_obj " + collion_obj.tag);
        if(collion_obj.tag=="Player"){
            string collided_letter = gameObject.tag;
            Debug.Log("Collided with letter : " + collided_letter);
            Destroy(gameObject);
            char inputLetter = char.Parse(collided_letter);
            //int c = 0;
            // Hint PopUp if letter = e
            if(inputLetter=='*')
            {
                Debug.Log("Hints");
                // tm.hints-=1;
                // PlayerPrefs.SetInt("hintsCollected",PlayerPrefs.GetInt("hintsCollected") + 1);
                // gs.goldIndex+=1;
                // if(gs.goldIndex<=2)
                // {
                //     mg.gamag.updateGameHint();

                // }
                // gs.goldObj.updateHint();
                // Camera.Pause();
            }
            // Fill blanks
            else{
                for (int i = 0; i < tm.solvedList.Count; i++)
                {
                    if(tm.solvedList[i] == inputLetter){
                        Debug.Log("Ayush");
                        tm.letterHolderList[i].text = inputLetter.ToString();
                        // var index = tm.displayCharacter.FindIndex(i => i.tag == gameObject.tag);
                        // if (index >= 0) {
                        //  tm.displayCharacter.RemoveAt(index);
                        // }
                        // var index1 = tm.correctCharacters.FindIndex(i => i.tag == gameObject.tag);
                        // if (index1 >= 0) {
                        //  tm.correctCharacters.RemoveAt(index1);
                        // }
                        //c=1;
                    }
                }
                // if(c == 0){
                //     LivesScript.lives -= 1;
                //     PlayerPrefs.SetInt("livesLeft", LivesScript.lives);
                //     if(LivesScript.lives == 0){
                //         PlayerPrefs.SetInt("livesLeft", 0);
                //         Camera.GameEnd();
                //         Player.body.isKinematic = true;
                //     }
                // }


            }
        }
        else{
          Debug.Log("Letter collided with letter");
          Destroy(gameObject);
        }
    }
    // Update is called once per frame
}
