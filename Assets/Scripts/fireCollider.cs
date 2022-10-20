using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider) {
      if(GetComponent<Collider>().tag=="Player"){
        Debug.Log("Fire Trigger");
        // Debug.Log(GetComponent<Collider>().isTrigger);
        // FindObjectOfType<Player>().TakeDamage(10);
        //Camera.GameEnd();
        //Player.body.isKinematic = true;
      }
      else{
        Debug.Log("Collide with blade");
        Destroy(collider.gameObject);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
