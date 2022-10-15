using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeDestroy : MonoBehaviour
{
  public float rotatespeed;

  void OnTriggerEnter(Collider collider) {
      if(collider.tag=="Player"){
        Debug.Log("Blade Trigger");
        // Debug.Log(collider.isTrigger);
        // Camera.GameEnd();
        // Player.body.isKinematic = true;
      }
      else{
        Debug.Log("Collide with blade");
        Destroy(collider);
      }
  }

  void Update(){
    transform.Rotate(0,0,rotatespeed);
  }

}
