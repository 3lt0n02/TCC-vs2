using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento_Dano : MonoBehaviour
{
    public float velocidade = 5.0f; // Velocidade de movimento para a esquerda.

    private Rigidbody2D rb;
    public int dano = 30;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Mover o objeto para a esquerda (velocidade negativa).
        rb.velocity = new Vector2(-velocidade, rb.velocity.y);
        Destroy(gameObject, 5.0f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ControleDeVida controleDeVida = collision.gameObject.GetComponent<ControleDeVida>();

            if (controleDeVida != null)
            {
                Debug.Log("Ta funcionando");
                controleDeVida.ReceberDano(dano);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControleDeVida controleDeVida = collision.GetComponent<ControleDeVida>();

            if (controleDeVida != null)
            {
                controleDeVida.ReceberDano(dano);
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
            
        }
    }*/
}
