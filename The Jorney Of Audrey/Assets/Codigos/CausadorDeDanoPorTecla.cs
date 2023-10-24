using UnityEngine;

public class CausadorDeDanoPorTecla : MonoBehaviour
{
    public int danoPorTecla = 10; // A quantidade de dano ao pressionar a tecla "X".

    // Atualize é chamado uma vez por quadro.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            CausarDanoAoJogador();
        }
    }

    void CausarDanoAoJogador()
    {
        SujeitoDeVida sujeitoDeVida = FindObjectOfType<SujeitoDeVida>();

        if (sujeitoDeVida != null)
        {
            sujeitoDeVida.Vida -= danoPorTecla; // Reduz a vida do jogador ao pressionar "X".
        }
    }
}