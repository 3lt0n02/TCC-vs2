using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleDeVida : MonoBehaviour
{
    public Slider barraDeVida;
    public int vidaMaxima = 100;
    private float vidaAtual;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarBarraDeVida();
    }

    private void Update()
    {
        Morreu();
    }

    public void ReceberDano(float dano)
    {
        StartCoroutine(MudarCorTemporaria(Color.red, 0.5f)); // Mudança temporária para vermelho por 0.5 segundos
        vidaAtual -= dano;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);
        AtualizarBarraDeVida();
    }

    private IEnumerator MudarCorTemporaria(Color novaCor, float duracao)
    {
        spriteRenderer.color = novaCor;
        yield return new WaitForSeconds(duracao);
        spriteRenderer.color = Color.white; // Retorna à cor original (branco no exemplo)
    }

    private void AtualizarBarraDeVida()
    {
        barraDeVida.value = vidaAtual;
        VerificarFimDeVida();
    }

    private void Morreu()
    {
        VerificarFimDeVida();
    }

    private void VerificarFimDeVida()
    {
        if (vidaAtual <= 0)
        {
            PlayerPrefs.SetString("faseMorreu", SceneManager.GetActiveScene().name);
            gamemanager.instance.GameOver();
        }
    }
}
