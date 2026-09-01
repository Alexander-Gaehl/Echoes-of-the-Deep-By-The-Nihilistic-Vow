using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPickUp : MonoBehaviour
{

    public GameObject GameManage;

    private GameManager gamma;

    public bool logs;

    private void Start()
    {

        gamma = GameManage.GetComponent<GameManager>();

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Enter");

        if (other.tag == "Player")
        {

            gamma.tempDev = true;

        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            gamma.tempDev = false;

        }

    }


    // Update is called once per frame
    void Update()
    {

        if (logs)
        {

            Debug.Log(gamma.tempDev);

        }

    }
}
