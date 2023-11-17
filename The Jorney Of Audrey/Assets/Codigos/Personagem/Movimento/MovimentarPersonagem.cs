using System.Collections;
using Codigos;
using Codigos.Inimigos.Vida;
using UnityEngine;

public class MovimentarPersonagem : MonoBehaviour
{
    [Header("Moedas")] 
    public PontuacaoHUD pontuacaoHUD;
    public int valorDaMoeda = 1;
    
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
    private float duracaoDoAtaque = 0.50f;
    private float tempoDecorrido;
    public int danoDoPlayer = 100;
    private float danoPadrao = 100f;
    private float danoAtual;
   

    
    [Header("Controle De Áudio")] 
    public AudioSource audioSourceMovimento; 
    public AudioClip somMovimento;
    
    public AudioSource audioSourceJump;
    public AudioClip somJump;

    public AudioSource audioSourceAttack;
    public AudioClip somAttack;
    
    

    private void Start()
    {
        danoAtual = danoPadrao;
        _animator.SetBool("Ataque", false);
        olharDireita = transform.localScale;
        olharEsquerda = transform.localScale;
        olharEsquerda.x = olharEsquerda.x * -1;
        rb2D = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        estaNoChao = Physics2D.OverlapCircle(detectorDeChao.position, 0.2f, oQueEhChao);
        Movimento();
        Pulo();
        ControleDeAtaque();
    }

    void Movimento()
    {
        direcao = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(direcao * velocidade, rb2D.velocity.y);

        if (direcao != 0 && estaNoChao)
        {
            _animator.SetBool("andando", true);
            
            if (!audioSourceMovimento.isPlaying)
            {
                audioSourceMovimento.clip = somMovimento;
                audioSourceMovimento.Play();
            }
        }
        else
        {
            audioSourceMovimento.Stop();
            _animator.SetBool("andando", false);
        }

        if (direcao > 0)
        {
            transform.localScale = olharDireita;
        }
        else if (direcao < 0)
        {
            transform.localScale = olharEsquerda;
        }
    }

    void Pulo()
    {
        if (Input.GetButtonDown("Jump") && estaNoChao)
        {
            rb2D.velocity = Vector2.up * forcaDoPulo;
            audioSourceJump.clip = somJump;
            audioSourceJump.Play();
        }

        _animator.SetBool("pulando", !estaNoChao);
        
    }

    void ControleDeAtaque()
    {
        if (Input.GetKeyDown(KeyCode.W) && !atacando)
        {
            AtivarAtaque();
            audioSourceAttack.clip = somAttack;
            audioSourceAttack.Play();
            
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
    public void AumentarDano(float aumento)
    {
        float novoDano = danoAtual * aumento;
        danoDoPlayer = (int)novoDano; 
        StartCoroutine(ReverterAumentoDano());
    }
    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator ReverterAumentoDano()
    {
        yield return new WaitForSeconds(5f);  
        
        danoDoPlayer = (int)danoPadrao;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pontoDeAtaque.position, alcanceDeAtaque);
    }
    
    private void ColetarMoeda()
    {
        // Lógica de coleta de moeda aqui
        int novaPontuacao = pontuacaoHUD.pontuacao + valorDaMoeda;  // Certifique-se de definir valorDaMoeda
        pontuacaoHUD.AtualizarPontuacao(novaPontuacao);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moeda"))
        {
            ColetarMoeda();
        }
    }

}
