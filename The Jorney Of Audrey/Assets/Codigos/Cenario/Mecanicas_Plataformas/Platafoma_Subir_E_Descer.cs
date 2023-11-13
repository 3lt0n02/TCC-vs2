using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Subir_E_Descer : MonoBehaviour
{
    private bool moverParaBaixo = true;

    public Transform pontoA;
    public Transform pontoB;

    public float velocidade;

    void Update()
    {
        if (transform.position.y > pontoA.position.y)
        {
            moverParaBaixo = true;
        }

        if (transform.position.y < pontoB.position.y)
        {
            moverParaBaixo = false;
        }

        if (moverParaBaixo)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // Obtenha o componente Rigidbody2D do jogador.
            Rigidbody2D playerRb = col.gameObject.GetComponent<Rigidbody2D>();

            // Defina a velocidade do jogador para a velocidade da plataforma em y.
            playerRb.velocity = new Vector2(playerRb.velocity.x, -velocidade);
        }
    }
}