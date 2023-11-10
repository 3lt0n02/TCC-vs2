using UnityEngine;

namespace Codigos.Cenario.Mecanicas_Plataformas
{
    public class AtivarPlataforma : MonoBehaviour
    {
        [Header("Variáveis de Controle de Plataformas")]
        public GameObject plataforma;

        private bool _estaPressionado;
        public Animator _animator;

        void Start()
        {
            plataforma.SetActive(false);
            _estaPressionado = false;
        }

        void Update()
        {
            if (_estaPressionado && Input.GetKeyDown(KeyCode.W))
            {
                _animator.SetBool("Ativado", true);
                plataforma.SetActive(true);
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