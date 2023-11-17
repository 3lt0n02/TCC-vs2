using UnityEngine;

namespace Codigos.Inimigos.Vida
{
    public class MoteDoInimigo : MonoBehaviour
    {
        public float vidaAtual = 100;
        public GameObject barreia;
        public void DanoNoImigo(int dano)
        {
            vidaAtual -= dano;
            if (vidaAtual <= 0)
            {
                Destroy(this.gameObject);
                if (barreia != null)
                {
                    barreia.SetActive(false);
                }
                
            }
        }
        
    }
}
