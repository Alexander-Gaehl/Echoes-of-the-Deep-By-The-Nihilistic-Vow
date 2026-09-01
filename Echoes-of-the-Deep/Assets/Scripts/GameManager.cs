using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool tempDev;
    public bool radDev;
    public bool mutDev;

    public int tempDevAmnt;
    public int RadDevAmnt;
    public int MutDevAmnt;

    public TextMeshProUGUI m_TempDevAmnt;
    public TextMeshProUGUI m_RadDevAmnt;
    public TextMeshProUGUI m_MutDevAmnt;

    enum GameState
    {

        MainMenu,

        Playing,

        Dead,

        Hmmm,

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }
}
