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
        SceneManager.LoadScene("Fase1");
    }

    public void FinalizarFase()
    {
        SceneManager.LoadScene("MenuInicial");
    }
    public void CarregarFaseMorreu()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("faseMorreu","MenuInicial"));
    }
    
    public void Tutorial()
    {
        SceneManager.LoadSceneAsync("Tutorial 3.0");
    }
    public void CarregarFase(string nomeDaFase)
    {
        SceneManager.LoadScene(nomeDaFase);
    }
    public void Fases()
    {
        SceneManager.LoadScene("Fases");
    }
    public void RecarregarCenaAnterior()
    {
        // Obtenha o índice da cena atual.
        int indiceCenaAtual = SceneManager.GetActiveScene().buildIndex;

        // Carregue a cena anterior (subtraindo 1 do índice da cena atual).
        int indiceCenaAnterior = Mathf.Max(0, indiceCenaAtual - 1); // Certifique-se de que o índice seja no mínimo 0.

        SceneManager.LoadScene(indiceCenaAnterior);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


}
