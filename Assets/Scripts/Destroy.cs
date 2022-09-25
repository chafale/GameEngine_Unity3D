using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mg = GameManager;
using gs = goldScript;
using mapgen = MapGenerator;

public class Destroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collide) {
        //Debug.Log("objected collided");
        string collided_letter = gameObject.tag;
        //Debug.Log("Collided with letter : " + collided_letter);
        Destroy(gameObject);
        char inputLetter = char.Parse(collided_letter);
        int c = 0;
        // Hint PopUp if letter = e
        if(inputLetter=='E')
        {
            gs.goldIndex+=1;
            if(gs.goldIndex<=2)
            {
                mg.gamag.updateGameHint();
               
            }
            gs.goldObj.updateHint();
            Camera.Pause();
            
        }
        // Fill blanks
        else{
            for (int i = 0; i < mg.solvedList.Count; i++)
            {
                Debug.Log("Letter Collided"+gameObject.tag);
               
               // Debug.Log(mg.solvedList[i]);
                if(mg.solvedList[i] == inputLetter){
                    mg.letterHolderList[i].text = inputLetter.ToString();
                    var index = mapgen.displayCharacter.FindIndex(i => i.tag == gameObject.tag); // like Where/Single
                    if (index >= 0) {   // ensure item found
                     Debug.Log("Element found at index"+ index);
                     mapgen.displayCharacter.RemoveAt(index);
                    }
                    for (int k = 0;k < mapgen.displayCharacter.Count;k++)
                     {
                       Debug.Log("Sanya"+mapgen.displayCharacter[k].tag);
                     }
                    c=1;
                    break;
                }
            }
            if(c == 0){
                Debug.Log("You hit the wrong letter");
                LivesScript.lives -= 1;
                if(LivesScript.lives == 0){
                    Camera.GameEnd();
                    Player.body.isKinematic = true;
                }
            }
        }
        int check = 0;
        // Check if all blanks are filled
        for (int i = 0; i < mg.solvedList.Count; i++)
        {
            char[] holder = mg.letterHolderList[i].text.ToCharArray();
            if(mg.solvedList[i] != holder[0]){
                check = 1;
                break;
            }
        }
        if(check==0){
          Camera.GameEnd();
          Player.body.isKinematic = true;
        }
    }
}
