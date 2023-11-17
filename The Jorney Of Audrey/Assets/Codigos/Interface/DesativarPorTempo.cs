using UnityEngine;

namespace Codigos.Interface
{
    public class DesativarPorTempo : MonoBehaviour
    {
        public GameObject objeto;
        public float tempoTotal;
        public float tempoAtual;
    
    
        void Start()
        {
            tempoAtual = tempoTotal;
            objeto.SetActive(true);

        }

   
        void Update()
        {
            tempoAtual -= Time.deltaTime;
                
            if (tempoAtual <= 0)
            {
                tempoAtual = 0;
                objeto.SetActive(false);
            
            }
        }
    }
}
