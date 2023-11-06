using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarPersonagem : MonoBehaviour
{
    [Header("Variáveis de Movimento")] 
    public float velocidade;
    private Rigidbody2D rb2D;
    private float direcao;
    private Vector3 olharDireita;
    private Vector3 olharEsquerda;

    [Header("Variáveis de Pulo")] 
    public float forcaDoPulo;
    public Transform detectorDeChao;
    public LayerMask oQueEhChao;
    public bool estaNoChao;
    [SerializeField]private Animator _animator;

    [Header("Variáveis de Ataque")] 
    public Transform pontoDeAtaque;
    public float alcanceDeAtaque = 0.5f;
    public LayerMask _Os_inimigos;
    private bool atacando = false;
    private float duracaoDoAtaque = 0.6f;
    private float tempoDecorrido;
    public int danoDoPlayer = 100;

    private void Start()
    {
        olharDireita = transform.localScale;
        olharEsquerda = transform.localScale;
        olharEsquerda.x = olharEsquerda.x * -1;
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        estaNoChao = Physics2D.OverlapCircle(detectorDeChao.position, 0.2f, oQueEhChao);
    }

    private void Update()
    {
       
        Movimento();
        Pulo();
        ControleDeAtaque();
    }

    void Movimento()
    {
        direcao = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(direcao * velocidade, rb2D.velocity.y);

        if (direcao > 0)
        {
            transform.localScale = olharDireita;
        }
        else if (direcao < 0)
        {
            transform.localScale = olharEsquerda;
        }

        _animator.SetBool("andando", Mathf.Abs(direcao) > 0);
    }

    void Pulo()
    {
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            rb2D.velocity = Vector2.up * forcaDoPulo;
        }

        _animator.SetBool("pulando", !estaNoChao);
    }

    void ControleDeAtaque()
    {
        if (Input.GetKeyDown(KeyCode.W) && !atacando)
        {
            AtivarAtaque();
        }

        tempoDecorrido += Time.deltaTime;

        if (atacando && tempoDecorrido >= duracaoDoAtaque)
        {
            DesativarAtaque();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void AtivarAtaque()
    {
        atacando = true;
        _animator.SetBool("Ataque", true);
        tempoDecorrido = 0f;
        Collider2D[] inimigos = Physics2D.OverlapCircleAll(pontoDeAtaque.position, alcanceDeAtaque, _Os_inimigos);

        // Aplica dano aos inimigos.
        foreach (Collider2D inimigo in inimigos)
        {
            inimigo.GetComponent<MoteDoInimigo>().DanoNoImigo(danoDoPlayer);
        }
    }

    void DesativarAtaque()
    {
        atacando = false;
        _animator.SetBool("Ataque", false);
    }

    // dezenhar os Alcance do Ataque
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pontoDeAtaque.position, alcanceDeAtaque);
    }
}
