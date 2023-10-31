using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaSlider : MonoBehaviour
{
    public SujeitoDeVida sujeitoDeVida; // Arraste o objeto SujeitoDeVida aqui na Inspector.
    public Slider barraDeVidaSlider; // O Slider que representa a barra de vida na UI.

    private void Start()
    {
        // Registre a função de atualização do Slider como observador do SujeitoDeVida.
        sujeitoDeVida.MudancaNaVida += AtualizarSlider;
        barraDeVidaSlider.maxValue = sujeitoDeVida.VidaMaxima;
    }

    private void AtualizarSlider(int vida)
    {
        // Atualize o valor do Slider com base na vida atual.
        barraDeVidaSlider.value = vida;
    }
}