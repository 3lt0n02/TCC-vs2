using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoTerrestre : MonoBehaviour
{
    [Header ("variaveis de movimento")]
    public float velocidade;

    public float dano;
    public Animator anim;

    private bool moverParaEsquerda = true;
    

    private Vector3 _olharDireita;
    private Vector3 _olharEsquerda;
    
    public Transform pontoA;
    public Transform pontoB;
    
    void Start()
    {
        _olharDireita = transform.localScale;
        _olharEsquerda = transform.localScale;
        _olharEsquerda.x = _olharEsquerda.x * -1;

    }
    void Update()
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
            transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
            transform.localScale = _olharDireita;
        }
        else
        {
            transform.position = new Vector2(transform.position.x+ velocidade * Time.deltaTime, transform.position.y );
            transform.localScale = _olharEsquerda;
        }
       
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ControleDeVida controleDeVida = collision.gameObject.GetComponent<ControleDeVida>();

            if (controleDeVida != null)
            {
                anim.SetBool("Atacando", true);
                controleDeVida.ReceberDano(dano * Time.deltaTime);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Atacando", false);
        }
    }

}
