using System.Collections;
using System.Collections.Generic;
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
    public float forsaDoPulo;
    public Transform detecarChao;
    public LayerMask oQueeChao;
    public bool taNoChao;
    [SerializeField] private Animator _animator;

    private Animator anim;
    private bool atacando = false;
    private float duracaoAtaque = 0.6f;
    private float tempoDecorrido;

    private void Start()
    {
        _olhaDireta = transform.localScale;
        _olhaEsquerda = transform.localScale;
        _olhaEsquerda.x = _olhaEsquerda.x * -1;
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        taNoChao = Physics2D.OverlapCircle(detecarChao.position, 0.2f, oQueeChao);
    }

    private void Update()
    {
        Movimento();
        Pulo();
        ControleDeAtaque();
    }

    void Movimento()
    {
        diresao = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(diresao * velocidade, rb2D.velocity.y);

        if (diresao > 0)
        {
            transform.localScale = _olhaDireta;
        }
        else if (diresao < 0)
        {
            transform.localScale = _olhaEsquerda;
        }

        _animator.SetBool("andando", Mathf.Abs(diresao) > 0);
    }

    void Pulo()
    {
        if (Input.GetButtonDown("Jump") && taNoChao)
        {
            rb2D.velocity = Vector2.up * forsaDoPulo;
        }

        _animator.SetBool("pulando", !taNoChao);
    }

    void ControleDeAtaque()
    {
        if (Input.GetKeyDown(KeyCode.W) && !atacando)
        {
            AtivarAtaque();
        }

        tempoDecorrido += Time.deltaTime;

        if (atacando && tempoDecorrido >= duracaoAtaque)
        {
            DesativarAtaque();
        }
    }

    void AtivarAtaque()
    {
        atacando = true;
        _animator.SetBool("Ataque", true);
        tempoDecorrido = 0f;
    }

    void DesativarAtaque()
    {
        atacando = false;
        _animator.SetBool("Ataque", false);
    }
}
