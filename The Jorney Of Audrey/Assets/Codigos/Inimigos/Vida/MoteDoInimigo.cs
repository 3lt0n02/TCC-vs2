using UnityEngine;

namespace Codigos.Inimigos.Vida
{
    public class MoteDoInimigo : MonoBehaviour
    {
        public float vidaAtual = 100;
        public GameObject barreia;
        public bool temBarreira = false;
        public void DanoNoImigo(int dano)
        {
            vidaAtual -= dano;
            if (vidaAtual <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        private void Update()
        {
            if (temBarreira)
            {
                if (barreia != null)
                {
                    if (vidaAtual <= 0)
                    {
                        barreia.SetActive(false);
                    } 
                }
            }
        }
    }
}
