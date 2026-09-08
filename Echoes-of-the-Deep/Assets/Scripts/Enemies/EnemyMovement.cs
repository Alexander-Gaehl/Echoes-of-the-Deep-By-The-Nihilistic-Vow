using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed = 2f;

    Rigidbody2D rb;

    public Transform target;

    Vector2 moveDirection;

    private bool follow;

    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = (target.position - transform.position).normalized;

        moveDirection = direction;

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
