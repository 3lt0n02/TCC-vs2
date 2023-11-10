using UnityEngine;

namespace Codigos.Cenario.Mecanicas_Plataformas
{
    public class AtivarPlataforma : MonoBehaviour
    {
        [Header("Variáveis de Controle de Plataformas")]
        public GameObject plataforma;
        public GameObject plataformaTranparente;

        private bool _estaPressionado;
        public Animator _animator;

        void Start()
        {
            plataforma.SetActive(false);
            plataformaTranparente.SetActive(true);
            _estaPressionado = false;
        }

        void Update()
        {
            if (_estaPressionado && Input.GetKeyDown(KeyCode.W))
            {
                _animator.SetBool("Ativado", true);
                plataforma.SetActive(true);
                plataformaTranparente.SetActive(false);
            }
            
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _estaPressionado = true;
            }
        }
        
    }
}