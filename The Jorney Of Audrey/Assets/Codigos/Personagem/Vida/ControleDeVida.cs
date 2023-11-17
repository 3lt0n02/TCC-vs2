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
    
    public bool temEscudo = false;
    
    private float tempoRestanteEscudo = 0f;
    private float duracaoEscudo = 5f;
    
    public GameObject objetoEscudo;

    public bool TemEscudo
    
    {
        get { return temEscudo; }
        set { temEscudo = value; }
    }
    public float TempoRestanteEscudo
    {
        get { return tempoRestanteEscudo; }
        set { tempoRestanteEscudo = value; }
    }

    public float DuracaoEscudo
    {
        get { return duracaoEscudo; }
    }

    private void Start()
    {
        
        vidaAtual = vidaMaxima;
        AtualizarBarraDeVida();
        objetoEscudo.SetActive(false);
        
    }

    private void Update()
    {
        Morreu();
        AtualizarTempoEscudo();
        
    }

    public void ReceberDano(float dano)
    {
        if (temEscudo)
        {
            return; // O jogador não recebe dano se o escudo estiver ativo
        }

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

    // ReSharper disable Unity.PerformanceAnalysis
    private void AtualizarBarraDeVida()
    {
        barraDeVida.value = vidaAtual;
        VerificarFimDeVida();
    }

    // ReSharper disable Unity.PerformanceAnalysis
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

    public void AumentarVida(int cura)
    {
        if (vidaAtual < vidaMaxima)
        {
            vidaAtual += cura;
            vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);
            AtualizarBarraDeVida();
        }
    }
    private void AtualizarTempoEscudo()
    {
        if (temEscudo)
        {
            tempoRestanteEscudo -= Time.deltaTime;

            if (tempoRestanteEscudo <= 0f)
            {
                DesativarEscudo();
            }
        }
    }
    private void DesativarEscudo()
    {
        temEscudo = false;
        tempoRestanteEscudo = 0f;
        objetoEscudo.SetActive(false);  // Desativa o GameObject do escudo
    }
    public void AtivarEscudo()
    {
        temEscudo = true;
        tempoRestanteEscudo = duracaoEscudo;
        objetoEscudo.SetActive(true);  // Ativa o GameObject do escudo
    }
}
