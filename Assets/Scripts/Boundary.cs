using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth, objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieving screen boundaries
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Retrieving player object height
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2 ;

        // Can be used while setting boundaries for objects.
        // objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        
        // Debug.Log(screenBounds.y * -1 + objectHeight);
    }

    // Update is called once per frame
    // Lateupdate called after every movement.
    void LateUpdate()
    {
        // New position
        Vector3 viewPos = transform.position;

        // To change position in vertical axis.
        viewPos.y = Mathf.Clamp(viewPos.y,  screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);

        // To change position in horizontal axis, required for objects.
        // viewPos.x = 

        // Setting the new position to object.
        transform.position = viewPos;
    }
}
