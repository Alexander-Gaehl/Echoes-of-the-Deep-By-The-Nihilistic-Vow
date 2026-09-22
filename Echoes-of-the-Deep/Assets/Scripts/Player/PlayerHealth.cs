using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private float startingHealth = 100f;

    public float health;


    public GameObject healthBar;

    private Image hlthBarImg;


    private void Awake()
    {
    
        hlthBarImg = healthBar.GetComponent<Image>();

    }

    private void Update()
    {
        
        hlthBarImg.fillAmount = health / startingHealth;

    }

}
