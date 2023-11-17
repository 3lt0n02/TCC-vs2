using System;
using UnityEngine;

namespace Codigos.PowerUps
{
    public class AumentoDeVida : MonoBehaviour
    {
        public int aumentoDeVida = 10;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                ControleDeVida controleDeVida = col.GetComponent<ControleDeVida>();
                
                if (controleDeVida != null)
                {
                    Debug.Log("Curando...");
                    controleDeVida.AumentarVida(aumentoDeVida);
                }
                
                Destroy(gameObject);
            }
            
        }
    }
}
