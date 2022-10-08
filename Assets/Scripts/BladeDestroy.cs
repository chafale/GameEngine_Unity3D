using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeDestroy : MonoBehaviour
{

  void OnTriggerEnter(Collider collider) {
      if(collider.tag=="Player"){
        Debug.Log("Trigger");
        Camera.GameEnd();
        Player.body.isKinematic = true;
      }
      else{
        Debug.Log("Collide with blade");
        Destroy(collider);
      }
  }

}
