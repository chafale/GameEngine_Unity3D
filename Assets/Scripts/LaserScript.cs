using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    //1
    public Sprite laserOnSprite;
    public Sprite laserOffSprite;
    //2
    public float toggleInterval = 0.5f;
    public float rotationSpeed = 0.0f;
    //3
    private bool isLaserOn = true;
    private float timeUntilNextToggle;
    //4
    private Collider laserCollider;
    private SpriteRenderer laserRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //1
        timeUntilNextToggle = toggleInterval;
        //2
        laserCollider = gameObject.GetComponent<Collider>();
        laserRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //1
        timeUntilNextToggle -= Time.deltaTime; 
        //2
        if (timeUntilNextToggle <= 0)
        {
            //3
            isLaserOn = !isLaserOn;
            //4
            laserCollider.enabled = isLaserOn;
            //5
            if (isLaserOn)
            {
                laserRenderer.sprite = laserOnSprite;
            }
            else
            {
                laserRenderer.sprite = laserOffSprite;
            }
            //6
            timeUntilNextToggle = toggleInterval;
        }
        //7
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
   }

   void OnTriggerEnter(Collider collider) {
      if(collider.tag=="Player"){
        Debug.Log("Laser Trigger");
        // Debug.Log(GetComponent<Collider>().isTrigger);
        // FindObjectOfType<Player>().TakeDamage(10);
        //Camera.GameEnd();
        //Player.body.isKinematic = true;
      }
      else{
        Debug.Log("Collide with Laser");
        Destroy(collider.gameObject);
      }
    }
}
