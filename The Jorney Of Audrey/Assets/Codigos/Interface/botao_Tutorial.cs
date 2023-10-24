using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class botao_Tutorial : MonoBehaviour
{
    [SerializeField] private Button _BotaoTutorial;

    private void Awake()
    {
        _BotaoTutorial.onClick.AddListener(IniciarTutorial);
    }

    private void IniciarTutorial()
    {
        gamemanager.instace.Tutorial();
    }
}
