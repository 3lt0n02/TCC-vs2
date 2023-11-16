using UnityEngine;

namespace Codigos.Inimigos.Vida
{
    public class MorteDoInimigoBoss : MonoBehaviour
    {
        public float vidaAtual = 100;
        public GameObject barreira;

        public void DanoNoImigo(int dano)
        {
            vidaAtual -= dano;
            if (vidaAtual <= 0)
            {
                Destroy(this.gameObject);
                barreira.SetActive(false);
            }
        }
    }
}
