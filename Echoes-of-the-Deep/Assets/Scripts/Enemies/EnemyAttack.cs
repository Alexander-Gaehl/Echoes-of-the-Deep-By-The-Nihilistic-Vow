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
    public int damage = 20; // The amount of damage the attack does

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void TriggerAttack()
    {
        anim.SetTrigger("Attack");
    }

    public void DealDamage()
    {
        // Detects players in range of the attack
        Collider2D[] hitPlayers = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        // Damages the player
        foreach (Collider2D player in hitPlayers)
        {
            // Assuming the player has a PlayerHealth component that handles taking damage
            if (player.TryGetComponent<PlayerHealth>(out PlayerHealth health))
            {
                health.TakeDamage(damage);
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
