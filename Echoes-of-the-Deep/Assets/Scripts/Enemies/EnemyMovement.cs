using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed = 2f;

    Rigidbody2D rb;

    private Animator animator;

    public Transform player;

    Vector2 moveDirection;

    private bool follow;

    // Attack parameters
    public float attackRange = 1f; // The range at which the enemy will stop moving and start attacking
    public float attackCooldown = 1f; // The cooldown time between attacks
    public float attackTimer = 0f; // A timer to keep track of the time since the last attack
    private EnemyAttack enemyAttack; // Reference to the EnemyAttack script

    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        attackScript = GetComponent<EnemyAttack>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            rb.velocity = Vector2.zero;
            animator.SetFloat("Speed", 0);
            return;
        }

        Vector3 direction = (player.position - transform.position).normalized;

        moveDirection = direction;

        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);

        // Calculate the distance to the target
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If the enemy is within attack range, stop moving and attack
        if (follow && distanceToPlayer <= attackRange)
        {
            // Stop moving
            animator.SetFloat("Speed", 0);

            // Handle attack cooldown
            HandleSpriteFlipping();

            if (Time.time >= attackTimer && enemyAttack != null)
            {
                // Trigger the attack
                enemyAttack.TriggerAttack();

                // Reset the attack timer
                attackTimer = Time.time + attackCooldown;
            }
            else
            {
                // If the enemy is not ready to attack, just stop moving
                animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
            }

            // Flip the sprite based on the direction of movement
            if (follow)
        { 
            if (moveDirection.x > 0)
            {
                HandleSpriteFipping();
            }
        }

    }

    void HandleSpriteFlipping()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag ("Player")
        {
            follow = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag ("Player")
        {
            follow = false;
        }

    }

    private void FixedUpdate()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Move towards the player if follow is true and the enemy is not within attack range   
        if (follow && distanceToPlayer > attackRange)
        {

            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;

        }
        else
        {
            // Stop moving if the enemy is within attack range or follow is false
            rb.velocity = new Vector2(0, 0);

        }

    }

}
