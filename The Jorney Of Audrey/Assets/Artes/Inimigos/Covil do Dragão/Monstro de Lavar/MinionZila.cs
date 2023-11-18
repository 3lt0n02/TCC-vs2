using UnityEngine;

namespace Artes.Inimigos.Covil_do_Dragão.Monstro_de_Lavar
{
    public class MinionZila : MonoBehaviour
    {
        public int danoAoJogador = 10;
        public float velocidade = 5f;

        void Update()
        {
            // Movimento para a esquerda
            transform.Translate(Vector2.left * (velocidade * Time.deltaTime));
            Destroy(gameObject, 7.0f);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            // Verifica se entrou em contato com o jogador
            if (other.CompareTag("Player"))
            {
                // Causa dano ao jogador
                ControleDeVida controleDeVida = other.GetComponent<ControleDeVida>();

                if (controleDeVida != null)
                {
                    controleDeVida.ReceberDano(danoAoJogador);
                }

                // Destroi o MinionZila após causar dano
                Destroy(gameObject);
            }
        }
    }
}