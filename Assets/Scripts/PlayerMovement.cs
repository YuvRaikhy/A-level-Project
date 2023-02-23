using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal"); // Takes input for x-axis (A and D or Left and Right arrow keys 
        float y = Input.GetAxis("Vertical"); // Takes input for y-axis (W and S or Up and Down arrow keys
        Vector2 movement = new Vector2(x, y); // Movement position based on input

        rb.velocity = (movement * speed); // USes rigidbody component to move the player to the Vector position "movement"
    }
}
