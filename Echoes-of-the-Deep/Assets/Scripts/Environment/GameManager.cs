using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool tempDev;
    public bool radDev;
    public bool mutDev;

    public int TempDevAmnt = 0;
    public int RadDevAmnt = 0;
    public int MutDevAmnt = 0;

    public TextMeshProUGUI m_TempDevAmnt;
    public TextMeshProUGUI m_RadDevAmnt;
    public TextMeshProUGUI m_MutDevAmnt;

    private PlayerHealth playerHealth;


    private void Start()
    {

        // Find the GameObject named "Enemy" in the hierarchy
        GameObject playerObject = GameObject.Find("Player");

        if (playerObject != null)
        {
            // Get the script component attached to that GameObject
            playerHealth = playerObject.GetComponent<PlayerHealth>();

        }

    }

    // Update is called once per frame
    private void Update()
    {

        m_TempDevAmnt.text = ($"Temp {TempDevAmnt}");
        m_RadDevAmnt.text = ($"Rad {RadDevAmnt}");
        m_MutDevAmnt.text = ($"Mut {MutDevAmnt}");


        float value = playerHealth.health;

        if (value <= 0)
        {

            SceneManager.LoadScene("GAMEOVER");

        }

    }
}
