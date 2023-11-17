using System;
using UnityEngine;

public class PowerUpEscudo : MonoBehaviour
{
    

   
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            AtivarEscudo(col.gameObject);
        }
    }

    private void AtivarEscudo(GameObject jogador)
    {
        ControleDeVida controleDeVida = jogador.GetComponent<ControleDeVida>();

        if (controleDeVida != null)
        {
            controleDeVida.TemEscudo = true;
            controleDeVida.TempoRestanteEscudo = controleDeVida.DuracaoEscudo; // Define o tempo restante para a duração do escudo
            controleDeVida.AtivarEscudo();
        }

        Destroy(gameObject); // Destrua o objeto de power-up de escudo
    }
}