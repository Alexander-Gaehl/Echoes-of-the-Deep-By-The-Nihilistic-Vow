using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator anim;

    // Attack parameters
    public Transform attackPoint; // The point from which the attack is initiated
    public float attackRange = 0.5f; // The range of the attack
    public LayerMask playerLayer; // The layer that the player is on
    public float damage = 20; // The amount of damage the attack does

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void TriggerAttack()
    {
        anim.SetTrigger("Attack");
        Debug.Log("Animator Trigger Called!"); 
    }


    public void DealDamage()
    {
        // Detects players in range of the attack
        Collider2D hitPlayers = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        // Damages the player
        if (hitPlayers != null)
        {
            if (hitPlayers.TryGetComponent<PlayerHealth>(out PlayerHealth health))
            {
                health.health -= damage;

                Debug.Log("Enemy has attacked! Current Health: " + health.health);

                // Check if the player's health has reached 0
                if (health.health <= 0)
                {
                    health.health = 0;
                    Debug.Log("Player has died!");
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
