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
                    GameObject gamemanager = Instantiate (Resources.Load<GameObject>("gamemanager"));
                    _instance = gamemanager.GetComponent<gamemanager>();
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
        SceneManager.LoadScene("HUD");
        SceneManager.LoadScene("Tutorial 3.0", LoadSceneMode.Additive);
    }

    
}
