using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleDeVida : MonoBehaviour
{
    public Slider barraDeVida; // Arraste o Slider da barra de vida aqui na Inspector.
    public int vidaMaxima = 100;
    private float vidaAtual;

    private void Start()
    {
        // Inicialize a vida atual com o valor máximo.
        vidaAtual = vidaMaxima;
        AtualizarBarraDeVida();
    }

    private void Update()
    {
       Morreu();
    }

    public void ReceberDano(float dano)
    {
        // Reduza a vida com base no dano recebido.
        vidaAtual -= dano;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima); // Garanta que a vida não ultrapasse os limites.

        // Atualize a barra de vida.
        AtualizarBarraDeVida();
    }

    private void AtualizarBarraDeVida()
    {
        // Atualize o valor do Slider com base na vida atual.
        barraDeVida.value = vidaAtual;

        // Você pode adicionar mais lógica aqui, como exibir uma mensagem de "Game Over" se a vida chegar a 0.
    }

    private void Morreu()
    {
        if (vidaAtual <= 0)
        {
            PlayerPrefs.SetString("faseMorreu",SceneManager.GetActiveScene().name);
            gamemanager.instace.GameOver(); 
        }
        
    }
}