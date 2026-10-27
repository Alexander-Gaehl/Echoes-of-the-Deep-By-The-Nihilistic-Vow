using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private float startingHealth = 100f;

    public float health = 100f;

    public Image healthBarImage;

    private void Update()
    {
        
        healthBarImage.fillAmount = health / startingHealth;

    }

}
