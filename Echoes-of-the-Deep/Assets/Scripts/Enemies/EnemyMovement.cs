using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed = 2f;

    Rigidbody2D rb;

    private Animator animator;

    public Transform target;

    Vector2 moveDirection;

    private bool follow;

    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;

        moveDirection = direction;

        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);

        // Flip the sprite based on the direction of movement
        if (follow)
        { 
            if (moveDirection.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // Face right
            }
            else if (moveDirection.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Face left
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            follow = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            follow = false;
        }

    }

    private void FixedUpdate()
    {
        if (follow)
        {

            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;

        }
        else
        {

            rb.velocity = new Vector2(0, 0);

        }

    }

}
