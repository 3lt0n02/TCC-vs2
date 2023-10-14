using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotãoDePause : MonoBehaviour
{
    [SerializeField] private Button BotaoPause;

    private void Awake()
    {
        BotaoPause.onClick.AddListener(BotaoClicado);
    }

    private void BotaoClicado()
    {
        gamemanager.instace.BotaoDePauser();
    }
}
