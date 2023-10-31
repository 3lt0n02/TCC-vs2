using UnityEngine;

public class CausadorDeDano : MonoBehaviour
{
    [SerializeField] private int dano = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifique se a colisão ocorreu com o jogador.
        if (collision.gameObject.CompareTag("Player"))
        {
            SujeitoDeVida jogadorSujeitoDeVida = collision.gameObject.GetComponent<SujeitoDeVida>();

            // Reduza a vida do jogador com base no dano.
            jogadorSujeitoDeVida.Vida -= dano;
            Debug.Log("Dano");
        }
    }
}