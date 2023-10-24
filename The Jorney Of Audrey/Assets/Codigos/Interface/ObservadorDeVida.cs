using UnityEngine;
using UnityEngine.UI;

public class ObservadorDeVida : MonoBehaviour
{
    public Slider barraDeVida; // Referência à barra de vida na interface.

    private void Start()
    {
        barraDeVida.value = 100;
        // Encontre o SujeitoDeVida na cena e inscreva-se no evento MudancaNaVida.
        SujeitoDeVida sujeitoDeVida = FindObjectOfType<SujeitoDeVida>();
        if (sujeitoDeVida != null)
        {
            sujeitoDeVida.MudancaNaVida += AtualizarBarraDeVida;
        }
    }

    private void AtualizarBarraDeVida(int novaVida)
    {
        // Atualize a barra de vida com o novo valor de vida.
        barraDeVida.value = novaVida;
    }
}