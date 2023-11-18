using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BebeDragao : MonoBehaviour
{
    public int dano = 15;

    public Animator ani;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se colidir com um jogador, causa dano e destroi a pedra
        if (other.CompareTag("Player"))
        {
            ani.SetBool("Atacando", true);
            ControleDeVida controleDeVida = other.GetComponent<ControleDeVida>();

            if (controleDeVida != null)
            {
                controleDeVida.ReceberDano(dano);
            }


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ani.SetBool("Atacando", false);

    }
}
