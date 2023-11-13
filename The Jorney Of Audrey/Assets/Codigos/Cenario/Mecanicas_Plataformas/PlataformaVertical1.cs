using UnityEngine;

namespace Codigos.Cenario.Mecanicas_Plataformas
{
    public class PlataformaVertical1 : MonoBehaviour
    {
        private bool moverParaBaixo = true;

        public Transform pontoA;
        public Transform pontoB;

        public float velocidade;

        void Update()
        {
            if (transform.position.y > pontoA.position.y)
            {
                moverParaBaixo = true;
            }

            if (transform.position.y < pontoB.position.y)
            {
                moverParaBaixo = false;
            }

            if (moverParaBaixo)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                col.transform.SetParent(transform);

                // Obtenha o componente Animator do jogador.
                Animator playerAnimator = col.gameObject.GetComponent<Animator>();

                // Defina a bool "pulando" como false no Animator.
                if (playerAnimator != null)
                {
                    playerAnimator.SetBool("pulando", true);
                }
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.transform.SetParent(null);
            }
        }
    }
}