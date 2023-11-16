using UnityEngine;

namespace Codigos.Inimigos.Movimento
{
    public class AreaAtaqueOrc : MonoBehaviour
    {
        private MovimentoOrc _movimentoOrc;
        private void Start()
        {
            _movimentoOrc = FindObjectOfType<MovimentoOrc>();
        
            if (_movimentoOrc == null)
            {
                Debug.LogError("Objeto com script MovimentoOrc não encontrado na cena.");
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.CompareTag("Player"))
            {
                _movimentoOrc.CausarDanoAoJogador();
            }
            
        }
    }
}
