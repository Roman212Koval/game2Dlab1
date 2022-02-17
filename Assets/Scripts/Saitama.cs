using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saitama : MonoBehaviour
{

    //Ox
    public int xVelocity = 5;
    // Oy
    public int yVelocity = 8;

    //
    private Rigidbody2D rigidBody;
    //========================================
    private void Start()
    {
        //
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log(rigidBody);
    }

    private void Update()
    {
        updatePlayerPosition();
        Debug.Log("Update");
    }

    private void updatePlayerPosition()
    {
        //
        float moveInput = Input.GetAxis("Horizontal");
        //
        float jumpInput = Input.GetAxis("Jump");
        if (moveInput < 0)
        { //
            rigidBody.velocity = new Vector2(-xVelocity, rigidBody.velocity.y);
        }
        else if (moveInput > 0)
        { //
            rigidBody.velocity = new Vector2(xVelocity, rigidBody.velocity.y);
        }
        if (jumpInput > 0)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, yVelocity);
        }
        Debug.Log(moveInput);
    }
}

