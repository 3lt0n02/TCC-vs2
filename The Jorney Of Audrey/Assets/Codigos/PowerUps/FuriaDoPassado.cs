using System.Collections.Generic;
using UnityEngine;

namespace Codigos.PowerUps
{
    public class FuriaDoPassado : MonoBehaviour
    {
        public float aumentoDano = 1.5f; // Ajuste o aumento de dano conforme necessário

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                AplicarFuriaDoPassado(other.gameObject);
                Destroy(gameObject);
            }
        }

        private void AplicarFuriaDoPassado(GameObject jogador)
        {
            MovimentarPersonagem movimentarPersonagem = jogador.GetComponent<MovimentarPersonagem>();

            if (movimentarPersonagem != null)
            {
                movimentarPersonagem.AumentarDano(aumentoDano);
            }
        }
    }
}