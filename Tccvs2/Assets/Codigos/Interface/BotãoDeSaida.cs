using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BotãoDeSaida : MonoBehaviour
{
    [SerializeField] private Button botaoDeSaida;
    public bool voltaparaoMenu;

    private void Awake()
    {
        if (voltaparaoMenu == false)
        {
            botaoDeSaida.onClick.AddListener(BotaoClicado);
        }
        else
        {
            botaoDeSaida.onClick.AddListener(OutroBotaoCliacado);
        }
        
    }

    private void BotaoClicado()
    {
        gamemanager.instace.BotaoDeSaida();
    }

    private void OutroBotaoCliacado()
    {
        gamemanager.instace.FimDoTurorial();
    }
}
