using UnityEngine;

public partial class AreaDeAtaque : MonoBehaviour
{
    public GameObject tatu; // Referência ao GameObject do Tatu
    public float aumentoVelocidade = 5.0f; // Aumento de velocidade desejado

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && tatu != null)
        {
            Animator tatuAnimator = tatu.GetComponent<Animator>();
            if (tatuAnimator != null)
            {
                // Ativar a animação "Atacando" no componente Animator do objeto Tatu.
                tatuAnimator.SetBool("Atacando", true);

                // Aumentar a velocidade do Tatu.
                MovimentoDoTatu movimentoDoTatu = tatu.GetComponent<MovimentoDoTatu>();
                if (movimentoDoTatu != null)
                {
                    movimentoDoTatu.AumentarVelocidade(aumentoVelocidade);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && tatu != null)
        {
            Animator tatuAnimator = tatu.GetComponent<Animator>();
            if (tatuAnimator != null)
            {
                // Desativar a animação "Atacando" quando o jogador sai da área de ataque.
                tatuAnimator.SetBool("Atacando", false);

                // Redefinir a velocidade do Tatu.
                MovimentoDoTatu movimentoDoTatu = tatu.GetComponent<MovimentoDoTatu>();
                if (movimentoDoTatu != null)
                {
                    movimentoDoTatu.ResetarVelocidade();
                }
            }
        }
    }
}