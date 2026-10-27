using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI Text;

    public float timepassed;

    public float a;

    public float startTime;

    public void SetTextTransparency(float alpha)
    {

        // alpha should be a value between 0.0f (invisible) and 1.0f (fully opaque)

        Color textColor = Text.color;

        textColor.a = alpha;        // Modify the alpha channel

        Text.color = textColor;   // Assign the updated color back

    }

    private void Start()
    {

        startTime = Time.time;

    }

    private void Update()
    {

        timepassed = Time.time - startTime;
        
        a = (255 - (timepassed * 100)) / 255;

        a = Mathf.Max(a, 0);

        SetTextTransparency(a);

        if (a == 0)
        {

            SceneManager.LoadScene("Main Menu");

        }


    }
}
