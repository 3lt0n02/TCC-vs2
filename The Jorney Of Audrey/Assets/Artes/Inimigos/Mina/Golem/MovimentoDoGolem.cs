using UnityEngine;

namespace Artes.Inimigos.Mina.Golem
{
    public class MovimentoDoGolem : MonoBehaviour
    {
        public float velocidade = 2.0f;
        public float duracaoMovimento = 5.0f; // Tempo em segundos para o movimento
        public float duracaoParadaMinima = 2.0f; // Duração mínima da parada em segundos
        public float duracaoParadaMaxima = 5.0f; // Duração máxima da parada em segundos

        private bool _moverParaFrente = true;
        private float _tempoDecorrido = 0f; // Tempo que o Golem tem se movido
        private float _tempoParadaAtual = 0f; // Tempo atual de parada
        private bool _parado = false;

        private Vector3 _olharDireita;
        private Vector3 _olharEsquerda;

        public Animator ani;
        public Transform ptDoDisparo;
        public GameObject pedraPrefab;

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
            if (!_parado)
            {
                if (_tempoDecorrido < duracaoMovimento)
                {
                    MovimentoSuaveEntrePontos();
                    ani.SetBool("Atacando", false);
                    _tempoDecorrido += Time.deltaTime;
                }
                else
                {
                    ani.SetBool("Atacando", true);
                    _parado = true;
                    _tempoParadaAtual = Random.Range(duracaoParadaMinima, duracaoParadaMaxima);

                    // Inicia a repetição da instância de pedras a cada 1 segundo
                    InvokeRepeating("InstanciarPedra", 0f, 1f);
                }
            }
            else
            {
                if (_tempoParadaAtual > 0f)
                {
                    _tempoParadaAtual -= Time.deltaTime; // Atualiza o tempo de parada
                }
                else
                {
                    ani.SetBool("Atacando", false);
                    _parado = false;
                    _tempoDecorrido = 0f; // Reinicia o tempo decorrido para o próximo movimento
                    InverterDirecao();

                    // Cancela a repetição da instância de pedras
                    CancelInvoke("InstanciarPedra");
                }
            }
        }

        void MovimentoSuaveEntrePontos()
        {
            if (_moverParaFrente)
            {
                transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);
                transform.localScale = _olharDireita;
            }
            else
            {
                transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
                transform.localScale = _olharEsquerda;
            }

            if (transform.position.x > pontoB.position.x && _moverParaFrente)
            {
                _moverParaFrente = false;
            }

            if (transform.position.x < pontoA.position.x && !_moverParaFrente)
            {
                _moverParaFrente = true;
            }
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        void InstanciarPedra()
        {
            // Instancia a pedra na posição do ponto de disparo
            GameObject pedraObj = Instantiate(pedraPrefab, ptDoDisparo.position, Quaternion.identity);
            Pedra scriptPedra = pedraObj.GetComponent<Pedra>();

            if (scriptPedra != null)
            {
                // Define a direção da pedra com base na direção do Golem
                scriptPedra.DefinirDirecao(transform.localScale.x);
            }
        }
        void InverterDirecao()
        {
            _moverParaFrente = !_moverParaFrente;
        }
    }
}
