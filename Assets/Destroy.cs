using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mg = GameManager;

public class Destroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collide) {
		//Debug.Log("objected collided");
        string collided_letter = gameObject.tag;
        //Debug.Log("Collided with letter : " + collided_letter);
        Destroy(gameObject);
        char inputLetter = char.Parse(collided_letter);
        
        for (int i = 0; i < mg.solvedList.Count; i++)
        {   
            Debug.Log(mg.solvedList[i]);
            if(mg.solvedList[i] == inputLetter){
                mg.letterHolderList[i].text = inputLetter.ToString();
            }
        }
	}
}
