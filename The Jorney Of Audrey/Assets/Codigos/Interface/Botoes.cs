using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Botoes : MonoBehaviour
{
    [SerializeField] private Button BotaoPLay;
    private void Awake()
    {
        BotaoPLay.onClick.AddListener(BotaoPlayClicado);
    }

    private void BotaoPlayClicado()
    {
        gamemanager.instace.DarPlayNoJogo();
    }
}