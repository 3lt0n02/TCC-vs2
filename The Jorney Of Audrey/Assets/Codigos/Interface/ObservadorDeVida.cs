using UnityEngine;
using UnityEngine.UI;

public class ObservadorDeVida : MonoBehaviour
{
    public SujeitoDeVida objetoComSujeitoDeVida;
    public Slider barraDeVidaSlider;// Arraste o objeto com SujeitoDeVida aqui no Inspector.

    private void Start()
    {
        // Certifique-se de que temos uma referência ao objeto com SujeitoDeVida.
        if (objetoComSujeitoDeVida == null)
        {
            objetoComSujeitoDeVida = FindObjectOfType<SujeitoDeVida>(); // Use FindObjectOfType para encontrar o objeto.
        }

        // Registre um método para ser chamado quando a vida mudar.
        objetoComSujeitoDeVida.MudancaNaVida += AtualizarBarraDeVida;
    }

    private void AtualizarBarraDeVida(int novaVida)
    {
        Debug.Log("Está funcionando");
        
        barraDeVidaSlider.value = novaVida;
        
        // quando a vida for menor que zero abra a tela de GameOver
        if (novaVida <= 0)
        {
            gamemanager.instace.GameOver();
        }
    }
}