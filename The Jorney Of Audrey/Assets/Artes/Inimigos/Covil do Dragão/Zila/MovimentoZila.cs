using UnityEngine;

public class MovimentoZila : MonoBehaviour
{
    private Animator _animator;
    private float _tempoDecorrido = 0f;
    public float intervaloAtaque = 5f; // Intervalo em segundos entre os ataques
    public float duracaoAtaque = 1.5f; // Duração do ataque em segundos
    public float intervaloTotal = 10f; // Intervalo total entre os ciclos de ataque
    public GameObject barreira; // Objeto de barreira
    public GameObject minionPrefab; // Prefab do Minion
    public Transform posicaoMinion; // Posição onde o Minion será instanciado

    void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Animator não encontrado no objeto Zila.");
        }

        if (barreira == null)
        {
            Debug.LogError("Objeto de barreira não atribuído ao script.");
        }

        if (minionPrefab == null)
        {
            Debug.LogError("Prefab de Minion não atribuído ao script.");
        }

        // Iniciar o primeiro ataque assim que o objeto for criado
        AtivarAtaque();
    }

    void Update()
    {
        _tempoDecorrido += Time.deltaTime;

        // Verificar se passou o intervalo total
        if (_tempoDecorrido >= intervaloTotal)
        {
            // Reiniciar o temporizador e iniciar o próximo ataque
            _tempoDecorrido = 0f;
            AtivarAtaque();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void AtivarAtaque()
    {
        if (_animator != null)
        {
            // Ativar a barreira quando estiver atacando
            if (barreira != null)
            {
                barreira.SetActive(true);
            }

            _animator.SetBool("Atacar", true);
            Invoke("DesativarAtaque", duracaoAtaque);

            // Instanciar Minions enquanto estiver atacando
            InvokeRepeating("InstanciarMinion", 0f, 1f);
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void DesativarAtaque()
    {
        if (_animator != null)
        {
            // Desativar a barreira quando não estiver atacando
            if (barreira != null)
            {
                barreira.SetActive(false);
            }

            _animator.SetBool("Atacar", false);

            // Parar a instanciação de Minions
            CancelInvoke("InstanciarMinion");

            // Agendar o próximo ataque após o intervalo de ataque
            Invoke("AtivarAtaque", intervaloAtaque);
        }
    }

    void InstanciarMinion()
    {
        if (minionPrefab != null && posicaoMinion != null)
        {
            Instantiate(minionPrefab, posicaoMinion.position, Quaternion.identity);
        }
    }
}
