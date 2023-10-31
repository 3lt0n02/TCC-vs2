using System;
using UnityEngine;

public class SujeitoDeVida : MonoBehaviour
{
    public int vida = 100; // A quantidade inicial de vida do jogador.
    public int VidaMaxima = 100;


    private void Start()
    {
        VidaMaxima = vida;
    }

    public event Action<int> MudancaNaVida; // Evento para notificar mudanças na vida.

    public int Vida
    {
        get { return vida; }
        set
        {
            vida = Mathf.Clamp(value, 0, 100); // Certifique-se de que a vida esteja no intervalo de 0 a 100.
            NotificarObservadores();
        }
    }

    private void NotificarObservadores()
    {
        MudancaNaVida?.Invoke(vida);
    }
}