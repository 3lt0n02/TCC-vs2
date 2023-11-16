using System;
using Unity.VisualScripting;
using UnityEngine;

public class MovimentoDoTatu : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade;
    public float velocidadePadrao = 3.0f;
    private float velocidadeAtual;

    private bool moverParaEsquerda = true;
    private Vector3 _olharDireita;
    private Vector3 _olharEsquerda;

    public int dano = 15;

    void Start()
    {
        _olharDireita = transform.localScale;
        _olharEsquerda = transform.localScale;
        _olharEsquerda.x = _olharEsquerda.x * -1;
    }

    void Update()
    {
        Movimentar();
    }

    void Movimentar()
    {
        if (transform.position.x > pontoA.position.x)
        {
            moverParaEsquerda = true;
        }

        if (transform.position.x < pontoB.position.x)
        {
            moverParaEsquerda = false;
        }

        if (moverParaEsquerda)
        {
            transform.Translate(Vector2.left * (velocidade * Time.deltaTime));
            // Aplicar escala invertida para olhar para a esquerda.
            transform.localScale = _olharEsquerda;
        }
        else
        {
            transform.Translate(Vector2.right * (velocidade * Time.deltaTime));
            // Restaurar a escala original para olhar para a direita.
            transform.localScale = _olharDireita;
        }
       
    }
    public void AumentarVelocidade(float aumento)
    {
        velocidadeAtual = velocidadePadrao + aumento;
    }

    public void ResetarVelocidade()
    {
        velocidadeAtual = velocidadePadrao;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ControleDeVida controleDeVida = col.gameObject.GetComponent<ControleDeVida>();
            
            if (controleDeVida != null)
            {
                controleDeVida.ReceberDano(dano);
            }
        }
    }
}