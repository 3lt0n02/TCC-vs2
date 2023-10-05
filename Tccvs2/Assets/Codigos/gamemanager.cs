using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public static gamemanager intance;

    void Start()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    // Update is called once per frame
    void Update()
    {
        DarPlayNoJogo();
    }

    public void DarPlayNoJogo()
    {
        SceneManager.LoadScene("Interface");
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Additive);
    }

    private void Awake()
    {
        if (intance == null)
        {
            intance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
