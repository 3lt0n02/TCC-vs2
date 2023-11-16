using UnityEngine;

namespace Codigos.Inimigos.Movimento
{
    public class MovimentoDoBoss : MonoBehaviour
    {
        public Transform pontoA;
        public Transform pontoB;
        public float velocidade;
        private bool moverParaPontoA = true;
        private bool emMovimento = true;

        public int dano = 10;

        public Animator ani;

        private void Update()
        {
            if (emMovimento)
            {
                MovimentarEntrePontos();
            }
        }

        private void MovimentarEntrePontos()
        {
            if (moverParaPontoA)
            {
                transform.Translate(Vector2.left * (velocidade * Time.deltaTime));
                if (transform.position.x <= pontoA.position.x)
                {
                    ani.SetBool("Andando", true);
                    moverParaPontoA = false;
                    InverterEscala();
                }
            }
            else
            {
                transform.Translate(Vector2.right * (velocidade * Time.deltaTime));
                if (transform.position.x >= pontoB.position.x)
                {
                    ani.SetBool("Andando", true);
                    moverParaPontoA = true;
                    InverterEscala();
                }
            }
        }

        private void InverterEscala()
        {
            Vector3 novaEscala = transform.localScale;
            novaEscala.x *= -1;
            transform.localScale = novaEscala;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                emMovimento = false;

                ControleDeVida controleDeVida = other.GetComponent<ControleDeVida>();

                if (controleDeVida != null)
                {
                    ani.SetBool("Ataque", true);
                    controleDeVida.ReceberDano(dano);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ani.SetBool("Ataque", false);
                emMovimento = true;
            }
        }
        
    
    }
}