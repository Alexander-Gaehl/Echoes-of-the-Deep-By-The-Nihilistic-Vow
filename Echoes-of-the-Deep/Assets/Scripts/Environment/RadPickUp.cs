using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadPickUp : MonoBehaviour
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

            gamma.radDev = true;

        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {

            gamma.radDev = false;

        }

    }


    // Update is called once per frame
    void Update()
    {

        if (logs)
        {

            Debug.Log(gamma.radDev);

        }

    }

}
