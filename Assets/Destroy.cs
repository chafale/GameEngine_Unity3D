using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collide) {
		Debug.Log("objected collided");
        string collided_letter = gameObject.tag;
        Debug.Log("Collided with letter : " + collided_letter);
        Destroy(gameObject);
        char inputLetter = char.Parse(collided_letter);
        // Should check if the letter is present in word
        // References GameManager.cs -> CheckLetter(char letter)
        // CheckLetter(inputLetter);
	}
}
