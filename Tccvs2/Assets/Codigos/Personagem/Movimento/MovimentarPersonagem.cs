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
    public float forsaDoPulo;
    public Transform detecarChao;
    public LayerMask oQueeChao;
    public bool taNoChao;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _olhaDireta = transform.localScale;
        _olhaEsquerda = transform.localScale;
        _olhaEsquerda.x = _olhaEsquerda.x * -1;
        
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        taNoChao = Physics2D.OverlapCircle(detecarChao.position, 0.2f, oQueeChao);
    }

    private void Update()
    {
        Movimento();
        Pulo();
        ataque();
        
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
    
    void Pulo()
    {
        if (Input.GetButtonDown("Jump") && taNoChao == true)
        {
            rb2D.velocity = Vector2.up * forsaDoPulo;
            _animator.SetBool("pulando", true);
        }

        if (taNoChao && rb2D.velocity.y == 0)
        {
            _animator.SetBool("pulando", false);
        }
    }

    void ataque()
    {

    }
}
