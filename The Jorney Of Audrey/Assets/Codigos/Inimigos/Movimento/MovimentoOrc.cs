using Codigos.Inimigos.Movimento;
using UnityEngine;

public class MovimentoOrc : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;

    public float velocidadeHorizontal;
    public float tempoDeEsperaMin = 5.0f; // Tempo mínimo em segundos para ficar parado
    public float tempoDeEsperaMax = 10.0f; // Tempo máximo em segundos para ficar parado
    private float tempoDecorrido;
    public float tempoDeEspera = 5.0f;
    
    public float intervaloDeAtaque = 3.0f; // Tempo entre ataques em segundos
    
    public Transform pontoDeAtaque;
    public float raioDaAreaDeAtaque = 1.5f;
    public float intervaloDeAtaqueInicial = 3.0f; // Tempo inicial entre ataques em segundos
    private float intervaloDeAtaqueAtual;
    
    private bool _emAtaque = false;
    private bool _moverParaEsquerda = true;
    private bool _ficarParado = false;
    
    private Vector3 _escalaOriginal;

    public Animator _Animator;

    public int dano = 10;

    public LayerMask player;
    
    private void Start()
    {
        
        Invoke("IniciarTempoDeEspera", Random.Range(tempoDeEsperaMin, tempoDeEsperaMax));
        intervaloDeAtaqueAtual = intervaloDeAtaqueInicial;
        InvokeRepeating("AtaquePeriodico", 0f, intervaloDeAtaqueAtual);
    }

    private void Update()
    {
        if (!_ficarParado)
        {
            MovimentarHorizontal();
        }
        else
        {
            tempoDecorrido += Time.deltaTime;
            if (tempoDecorrido >= tempoDeEspera)
            {
                _ficarParado = false;
                tempoDecorrido = 0f;
                transform.localScale = _escalaOriginal;
            }
            else
            {
                _Animator.SetBool("Andado", false);
            }
        }

        if (_emAtaque && !_ficarParado)
        {
            // Agora, verifique se já passou o intervalo de ataque
            if (Time.time >= intervaloDeAtaqueAtual)
            {
                _emAtaque = false;
                _Animator.SetBool("Ataque", false);
                IniciarTempoDeEspera();
                DefinirNovoIntervaloDeAtaque(10.0f);
            }

            // Remova a animação de ataque se não estiver causando dano
            if (!_Animator.GetBool("Ataque"))
            {
                _Animator.SetBool("Ataque", false);
            }
        }

        // Realize o ataque apenas se não estiver no intervalo de ataque
        if (!_emAtaque && !_ficarParado)
        {
            Atacar();
        }
    }

    private void MovimentarHorizontal()
    {
        if (transform.position.x > pontoA.position.x)
        {
            _moverParaEsquerda = true;
        }

        if (transform.position.x < pontoB.position.x)
        {
            _moverParaEsquerda = false;
        }

        if (_moverParaEsquerda)
        {
            _Animator.SetBool("Andado", true);
            transform.Translate(Vector2.left * (velocidadeHorizontal * Time.deltaTime));
            // Aplicar escala invertida para olhar para a esquerda.
            transform.localScale = new Vector3(2, 2, 1);
        }
        else
        {
            _Animator.SetBool("Andado", true);
            transform.Translate(Vector2.right * (velocidadeHorizontal * Time.deltaTime));
            // Restaurar a escala original para olhar para a direita.
            transform.localScale = new Vector3(-2, 2, 1);
        }
    }

    public void IniciarTempoDeEspera()
    {
        _ficarParado = true;
        _escalaOriginal = transform.localScale;
        Invoke("RetomarMovimento", Random.Range(tempoDeEsperaMin, tempoDeEsperaMax));
    }

    private void RetomarMovimento()
    {
        _ficarParado = false;
        transform.localScale = _escalaOriginal;
        Invoke("IniciarTempoDeEspera", Random.Range(tempoDeEsperaMin, tempoDeEsperaMax));
    }
    public void Atacar()
    {
        _emAtaque = true;

        // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
        CausarDanoAoJogador();

        // Verifique se causou dano antes de definir o estado de ataque no Animator
        if (_Animator.GetBool("Ataque"))
        {
            _Animator.SetBool("Ataque", true);
        }
    }
    public void CausarDanoAoJogador()
    {
        // Encontrar todos os objetos na área de ataque (usando OverlapCircleAll, por exemplo)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pontoDeAtaque.position, raioDaAreaDeAtaque,player);

        foreach (Collider2D collider in colliders)
        {
            // Verificar se o collider tem a tag "Player" e se o movimento não está parado
            if (collider.CompareTag("Player") && !_ficarParado)
            {
                // Obter o componente ControleDeVida do jogador
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                ControleDeVida controleDeVida = collider.GetComponent<ControleDeVida>();

                // Se o componente ControleDeVida existir, causar dano ao jogador
                if (controleDeVida != null)
                {
                    // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                    controleDeVida.ReceberDano(dano);
                }
            }
        }
    }
    
    private void DefinirNovoIntervaloDeAtaque(float novoIntervalo)
    {
        intervaloDeAtaqueAtual = novoIntervalo;

        // Cancela a rotina atual e inicia uma nova com o intervalo atualizado
        CancelInvoke("AtaquePeriodico");
        InvokeRepeating("AtaquePeriodico", 0f, intervaloDeAtaqueAtual);
    }
    private void OnDrawGizmos()
    {
        if (pontoDeAtaque == null)
            return;

        // Define a cor do Gizmo para visualização
        Gizmos.color = Color.red;

        // Desenha o círculo de busca ao redor do pontoDeAtaque na cena
        Gizmos.DrawWireSphere(pontoDeAtaque.position, raioDaAreaDeAtaque);
    }
  
   
}