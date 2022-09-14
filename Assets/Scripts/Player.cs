using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // To set the speed of the player
    public float playerSpeed;

    // To move the player
    private Rigidbody2D rgbody;

    // To move player based on input
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        rgbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // Detection of inputs is done in update function
    void Update()
    {
        // up arrow = 1, down arrow = -1
        float directionY = Input.GetAxisRaw("Vertical");
        
        // Normalized for stability
        // x = 0, since the player doesn't need to move on horizontal axis.
        playerDirection = new Vector2(0, directionY).normalized;
    }

    // called once per physics engine [ updates to rigdbody ]
    void FixedUpdate()
    {
        rgbody.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }
}
