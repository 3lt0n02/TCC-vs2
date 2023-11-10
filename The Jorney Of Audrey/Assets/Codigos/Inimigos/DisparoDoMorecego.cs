using UnityEngine;

namespace Codigos.Inimigos
{
    public class DisparoDoMorecego : MonoBehaviour
    {
    
        public GameObject objetoParaInstanciar;
        private float proximoTempoDeInstanciacao;
        [SerializeField] private float tempoMinimo = 1.0f; // Tempo mínimo de instanciação
        [SerializeField] private float tempoMaximo = 3.0f; // tempo maximo de instaciação
        public Transform pontoDeInstancia;
        void Start()
        {
            proximoTempoDeInstanciacao = Time.time + Random.Range(tempoMinimo, tempoMaximo);
        
        }

    
        void Update()
        {
            if (Time.time >= proximoTempoDeInstanciacao)
            {
                Instantiate(objetoParaInstanciar, pontoDeInstancia.position, pontoDeInstancia.rotation);
                // Atualize o próximo tempo de instanciação com base no intervalo definido.
                proximoTempoDeInstanciacao = Time.time + Random.Range(tempoMinimo, tempoMaximo);
            }
        
        }
    }
}
