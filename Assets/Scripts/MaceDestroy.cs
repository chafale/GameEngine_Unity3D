using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceDestroy : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 2;

    float startingY;
    private int dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        startingY=transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime*dir);
        if (transform.position.y <startingY || transform.position.y > startingY + range)
        dir *=-1;

    }

    void OnTriggerEnter(Collider collider) {
      if(collider.tag=="Player"){
        Debug.Log("Trigger");
        Debug.Log(collider.isTrigger);
        Camera.GameEnd();
        Player.body.isKinematic = true;
      }
      else{
        Debug.Log("Collide with blade");
        Destroy(collider);
      }
  }
}
