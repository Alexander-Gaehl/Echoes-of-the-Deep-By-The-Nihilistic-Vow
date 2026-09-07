using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D body;

    public Animator animator;

    SpriteRenderer sprite; 

    float horizontal;

    float vertical;

    public float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;


    void Start()
    {

        body = GetComponent<Rigidbody2D>();

        sprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        // Gives a value between -1 and 1

        horizontal = Input.GetAxisRaw("Horizontal");

        // -1 is left 1 is right

        vertical = Input.GetAxisRaw("Vertical");

        // -1 is down 1 is up

        // Calculate the movement speed based on the horizontal and vertical input
        float movementSpeed = new Vector2(horizontal, vertical).sqrMagnitude;

        animator.SetFloat("Speed", movementSpeed);

        Debug.Log("Script Input -> Horiz: " + Mathf.Abs(horizontal) + " Vert: " + vertical);

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
            animator.SetFloat("Vertical", vertical);
        }

        // Flip the sprite based on the direction of movement

        if (horizontal < 0)
        {
            // Flip the sprite to face left

            sprite.flipX = true;
        }
        else if (horizontal > 0)
        {
            // Flip the sprite to face right

            sprite.flipX = false;
        }
    }

    void FixedUpdate()
    {
        float currentHorizontal = horizontal;
        float currentVertical = vertical;

        if (currentHorizontal != 0 && currentVertical != 0)
        {

            // Check for diagonal movement

            // limit movement speed diagonally, so you move at a pace that feels right

            currentHorizontal *= moveLimiter;
            
            currentVertical *= moveLimiter;

        }

        body.velocity = new Vector2(currentHorizontal * runSpeed, currentVertical * runSpeed);


    }


}