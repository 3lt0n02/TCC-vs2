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

        public Transform pontoA;
        public Transform pontoB;

        public Animator ani;

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
                    _tempoDecorrido += Time.deltaTime; // Atualiza o tempo decorrido
                }
                else
                {
                    ani.SetBool("Atacando", true);
                    _parado = true;
                    _tempoParadaAtual = Random.Range(duracaoParadaMinima, duracaoParadaMaxima);
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
                    _parado = false;
                    _tempoDecorrido = 0f; // Reinicia o tempo decorrido para o próximo movimento
                    InverterDirecao();
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

        void InverterDirecao()
        {
            _moverParaFrente = !_moverParaFrente;
        }
    }
}
