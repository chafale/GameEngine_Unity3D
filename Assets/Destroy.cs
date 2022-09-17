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
	}
}
