using System;
using Cinemachine;
using UnityEngine;

public class MovimentarPersonagem : MonoBehaviour
{
    [Header("Variaves de Movemento ")]
    public float velocidade; 
    private Rigidbody2D rb2D;
    private float diresao;
    private Vector3 _olhaDireta;
    private Vector3 _olhaEsquerda;
    
    [Header("Variaves do Pulo")]
    private int puloExtra = 1;
    public float forsaDoPulo;
    public Transform detecarChao;
    public LayerMask oQueeChao;
    public bool taNoChao;

    [Header("Variaves de Ataque")] 
    public Transform ataqueChek;
    public float raioDeAtque;
    public LayerMask inimigo;
    public float tempoDeRecargar;
    
    
    
   

    private void Start()
    {
        _olhaDireta = transform.localScale;
        _olhaEsquerda = transform.localScale;
        _olhaEsquerda.x = _olhaEsquerda.x * -1;
        
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movimento();
        Pulo();
        flip();
        playerAtaque();
        taNoChao = Physics2D.OverlapCircle(detecarChao.position, 0.2f, oQueeChao );
    }

    void Movimento()
    {
        diresao = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(diresao * velocidade, rb2D.velocity.y);

        if (diresao > 0)
        {
            transform.localScale = _olhaDireta;
        }

        if (diresao < 0)
        {
            transform.localScale = _olhaEsquerda;
        }
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
        if (Input.GetButtonDown("Jump") && taNoChao == true)
        {
            rb2D.velocity = Vector2.up * forsaDoPulo;
        }

        if (Input.GetButtonDown("Jump") && taNoChao == false && puloExtra > 0)
        {
            rb2D.velocity = Vector2.up * forsaDoPulo;
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
