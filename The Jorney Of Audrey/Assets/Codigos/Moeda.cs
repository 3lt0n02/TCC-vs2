using Codigos;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    public int valor = 1;  // Valor da moeda que o jogador receberá

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ColetarMoeda(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void ColetarMoeda(GameObject jogador)
    {
        PontuacaoHUD pontuacaoHUD = jogador.GetComponent<PontuacaoHUD>();
        if (pontuacaoHUD != null)
        {
            pontuacaoHUD.AtualizarPontuacao(valor);
        }
    }
}