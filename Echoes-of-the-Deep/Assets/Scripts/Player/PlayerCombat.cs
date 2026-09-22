using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCombat : MonoBehaviour
{
    private Animator anim;
    private int comboCount = 0;
    private float lastClickTime = 0f;

    public float maxComboDelay = 0.8f; // Maximum time allowed between clicks for combo

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Reset combo if time exceeded
        if (Time.time - lastClickTime > maxComboDelay)
        {
            ResetCombo();
        }

        // Left click for attack
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        lastClickTime = Time.time;
        comboCount++;

        // Reset combo count if it exceeds the maximum allowed combo
        if (comboCount > 3)
        {
            ResetCombo();
        }

        // Update Animator parameters based on combo count
        anim.SetInteger("ComboCount", comboCount);
        anim.SetTrigger("Attack");
    }

    // Reset combo count and Animator parameter
    public void ResetCombo()
    {
        comboCount = 0;
        anim.SetInteger("ComboCount", 0);
    }
}
