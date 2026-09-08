using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play() 
    {
        //This loads the next scene of the build order.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*public void Options() 
    {
        SceneManager.LoadScene("Settings");
    }*/

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game.");
    }
}
