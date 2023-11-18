using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    private static gamemanager _instance;

    public static gamemanager instance
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
        SceneManager.LoadSceneAsync("MenuInicial");
    }
    

    public void FinalizarFase()
    {
        SceneManager.LoadScene("Win");
    }

    public void FinalizarFase1()
    {
        SceneManager.LoadScene("TelaWinFase2");
    }
    public void FinalizarFase2()
    {
        SceneManager.LoadScene("TelaWinFase1");
    }
    public void CarregarFaseMorreu()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("faseMorreu","MenuInicial"));
    }
    
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial 3.0");
    }
    public void Fases()
    {
        SceneManager.LoadScene("Fases");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void fase1()
    {
        SceneManager.LoadScene("Fase 1");
    }
    public void fase2()
    {
        SceneManager.LoadScene("Fase 2");
    }
    public void fase3()
    {
        SceneManager.LoadScene("Fase 3");
    }
    public void shoope()
    {
        SceneManager.LoadScene("Shoope");
    }


}
