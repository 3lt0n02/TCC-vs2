using UnityEngine;

namespace Codigos.Cenario.Mecanicas_Plataformas
{
    public class AtivarPlataforma : MonoBehaviour
    {
        [Header ("variaveis de controle de plataformas")]
        public GameObject plataforma;

        private bool _estaPressionado;

        void Start()
        {
            plataforma.SetActive(false);
        }

        void Update()
        {
            if (_estaPressionado)
            {
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
