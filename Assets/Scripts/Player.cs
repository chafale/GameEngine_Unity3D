using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    
    public static Rigidbody body;
    public bool gameOver = false;
    private Vector2 playerDirection;
    public DateTime gameStartTime;
    public int maxHealth = 100;
    public int currentHealth;
    // public HealthBar healthBar;
    
    public static int playerSpeed;
    // Use this for initialization
    void Start () {
        playerSpeed = 5;
        currentHealth = maxHealth;
        FindObjectOfType<HealthBar>().SetMaxHealth(maxHealth);
        body = GetComponent<Rigidbody>();
        gameStartTime = System.DateTime.Now;
        PlayerPrefs.SetString("gameStartTime", gameStartTime.ToString());
        
    }
    
    void Update()
    {
        // up arrow = 1, down arrow = -1
        float directionY = Input.GetAxisRaw("Vertical");
        
        // Normalized for stability
        // x = 0, since the player doesn't need to move on horizontal axis.
        playerDirection = new Vector2(0, directionY).normalized;
    }

    void FixedUpdate () {
        // if (gameOver) {
            
        //  if (Input.GetMouseButtonDown(0)) {
        //      SceneManager.LoadScene("Game");
        //  }
        //  return;
        // }
        // if (Input.GetMouseButton(0)) {
        //  body.AddForce(new Vector3(0, 50,0), ForceMode.Acceleration);
        // } else if (Input.GetMouseButtonUp(0)) {
        //  body.velocity *= 0.25f;
        // }
        body.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }
    
    void OnTriggerEnter(Collider collider) {
        gameOver = true;
        body.isKinematic = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        FindObjectOfType<HealthBar>().SetHealth(currentHealth);
    }
}