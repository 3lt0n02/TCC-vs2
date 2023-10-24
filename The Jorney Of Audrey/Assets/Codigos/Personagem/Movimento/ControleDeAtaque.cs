using UnityEngine;

public class ControleDeAtaque : MonoBehaviour
{
    private Animator anim;
    private bool atacando = false;
    private float duracaoAtaque = 0.6f;
    private float tempoDecorrido;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !atacando)
        {
            AtivarAtaque();
        }

        // Atualize o tempo decorrido.
        tempoDecorrido += Time.deltaTime;

        // Verifique se o ataque deve ser desativado com base na duração.
        if (atacando && tempoDecorrido >= duracaoAtaque)
        {
            DesativarAtaque();
        }
    }

    void AtivarAtaque()
    {
        atacando = true;
        anim.SetBool("Ataque", true);
        tempoDecorrido = 0f; // Zere o tempo decorrido quando o ataque é ativado.
    }

    void DesativarAtaque()
    {
        atacando = false;
        anim.SetBool("Ataque", false);
    }
}