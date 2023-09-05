using System;
using UnityEngine;

public class MovimentarPersonagem : MonoBehaviour
{
    [Header("Variaves de Movemento ")]
    public float velocidade = 5f; 
    private Rigidbody2D rb2D;
    private int puloExtra = 1;
    public float forsaDoPulo;
    private bool taNoChao;

    [Header("Variaves de Ataque")] 
    public Transform ataqueChek;
    public float raioDeAtque;
    public LayerMask inimigo;
    public float tempoDeRecargar;
    
    
    
   

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movimento();
        Pulo();
        flip();
        playerAtaque();
    }

    void Movimento()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        Vector2 direcaoMovimento = new Vector2(movimentoHorizontal, 0f);
        Vector2 velocidadeMovimento = direcaoMovimento * velocidade;

        rb2D.velocity = velocidadeMovimento;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chão"))
        {
            taNoChao = true;
        }
    }
    void Pulo()
    {
        if (Input.GetKeyDown(KeyCode.Space) && taNoChao)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, forsaDoPulo);
            taNoChao = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && taNoChao == false && puloExtra == 1)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, forsaDoPulo);
            taNoChao = false;
            puloExtra--;
        }

        if (taNoChao)
        {
            puloExtra = 1;
        }
    }

    void flip()
    {
        ataqueChek.localPosition = new Vector2(-ataqueChek.localPosition.x, ataqueChek.localPosition.y);
    }

    void playerAtaque()
    {
        Collider2D[] inimigosAtaque = Physics2D.OverlapCircleAll(ataqueChek.position, raioDeAtque, inimigo);
        
    }
}
