using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private Vector2 movement;

    public float moveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        MovePosition();
    }

    private void ProcessInputs()
    {
        /* 
            "GetAxis" returns a value between 0 and 1.
            "GetAxisRaw" returns a value of either 0 or 1.
        */
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        movement = new Vector2(xMove, yMove).normalized; // "normalized" returns the magnitude of 1 to a diagonal movement.
    }

    private void MovePosition()
    {
        rigidBody2D.MovePosition(rigidBody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
        //rigidBody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
