using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{

    public GameObject GameManage;
    private GameManager gamma;
    public int maxTempDevs = 5;
    public int maxRadDevs = 5;
    public int maxMutDevs = 5;

    private void Start()
    {

        gamma = GameManage.GetComponent<GameManager>();

    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (gamma.tempDev)
            {

                if (!(gamma.TempDevAmnt >= maxTempDevs))
                {

                    gamma.TempDevAmnt++;

                }

                else
                {

                    Debug.Log("Too Many Temperature Devices");

                }

            }

            else if (gamma.radDev)
            {

                if (!(gamma.RadDevAmnt >= maxRadDevs))
                {

                    gamma.RadDevAmnt++;

                }

                else
                {

                    Debug.Log("Too Many Radiation Devices");

                }

            }

            else if (gamma.mutDev)
            {

                if (!(gamma.MutDevAmnt >= maxMutDevs))
                {

                    gamma.MutDevAmnt++;

                }

                else
                {

                    Debug.Log("Too Many Mutation Devices");

                }

            }

            else
            {

                Debug.Log("Can't Pick up");

            }

        }

    }
}
