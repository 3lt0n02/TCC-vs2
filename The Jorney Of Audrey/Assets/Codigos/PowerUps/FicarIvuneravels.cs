using UnityEngine;

namespace Codigos.PowerUps
{
    public class FicarIvuneravels : MonoBehaviour
    {
        public GameObject escudo;
        void Start()
        {
            escudo.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                ControleDeVida controleDeVida = col.GetComponent<ControleDeVida>();
                
                if (controleDeVida != null)
                {
                    escudo.SetActive(true);
                }
                
            }
        
            Destroy(gameObject);
        }
    }
}
