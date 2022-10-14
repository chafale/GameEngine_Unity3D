using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider) {
      if(GetComponent<Collider>().tag=="Player"){
        Debug.Log("Trigger");
        Debug.Log(GetComponent<Collider>().isTrigger);
        Camera.GameEnd();
        Player.body.isKinematic = true;
      }
      else{
        Debug.Log("Collide with blade");
        Destroy(GetComponent<Collider>());
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
