using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class FaseInfo
{
    public string nomeDaFase;
    public int numeroDaFase;
}

public class ButtonLevels1 : MonoBehaviour
{
    [SerializeField] private Button _Botão;
    [SerializeField] private FaseInfo[] fases;

    private void Awake()
    {
        _Botão.onClick.AddListener(() => CarregarFaseSelecionada());
    }

    private void CarregarFaseSelecionada()
    {
        if (fases.Length == 0)
        {
            Debug.LogWarning("Nenhuma fase definida para carregar.");
            return;
        }

        // Aqui você pode escolher qual fase carregar com base na seleção no Inspector.
        int faseSelecionada = 0; // Esta é apenas uma escolha padrão.
        gamemanager.instance.CarregarFase(fases[faseSelecionada].nomeDaFase);
    }
}