using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnTriggerEnter(Collider collide) {
		Debug.Log("objected collided");
            Destroy(gameObject);
	}
    // private void OnCollisionEnter (Collision collision)
    // {
        
    //         Debug.Log("objected collided");
    //         Destroy(collision.gameObject);
    //         Destroy(gameObject);
        
    
    // }
}
