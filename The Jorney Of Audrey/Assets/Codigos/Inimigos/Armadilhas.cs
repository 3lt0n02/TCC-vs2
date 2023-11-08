using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armadilhas : MonoBehaviour
{
    public int dano = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControleDeVida controleDeVida = collision.GetComponent<ControleDeVida>();

            if (controleDeVida != null)
            {
                controleDeVida.ReceberDano(dano);
            }
        }
    }
}
