using System;
using UnityEngine;
using UnityEngine.UI;

namespace Codigos
{
    public class PontuacaoHUD : MonoBehaviour
    {
        public Text pontuacaoText;
        public int pontuacao = 0;

        private void Start()
        {
            pontuacao = 0;
            pontuacaoText.text = $"Moedas : {pontuacao}";
        }

        public void AtualizarPontuacao(int novaPontuacao)
        {
            pontuacao = novaPontuacao;
            pontuacaoText.text = $"Moedas: {pontuacao}";
        }
    }
}