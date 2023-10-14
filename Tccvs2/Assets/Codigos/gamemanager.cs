using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    private static gamemanager _instance;

    public static gamemanager instace
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<gamemanager>();
                if (_instance == null)
                {
                    GameObject gamemanageroGameObject = Instantiate (Resources.Load<GameObject>("gamemanager"));
                    _instance = gamemanageroGameObject.GetComponent<gamemanager>();
                }

            }

            return _instance;
        }
    }
    void Awake()
    {
       DontDestroyOnLoad(this);
    }
   
    void Start()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    
    void Update()
    {
    }

    public void DarPlayNoJogo()
    {
        SceneManager.LoadScene("Interface");
        SceneManager.LoadSceneAsync("Tutorial 3.0", LoadSceneMode.Additive);
    }

    public void FimDoTurorial()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void BotaoDePauser()
    {
        SceneManager.LoadScene("TelaDePauser", LoadSceneMode.Additive);
    }

    public void BotaoDeSaida()
    {
        SceneManager.UnloadSceneAsync("TelaDePauser");
    }

    
}
