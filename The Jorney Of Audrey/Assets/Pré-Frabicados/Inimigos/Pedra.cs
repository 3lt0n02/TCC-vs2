using UnityEngine;

public class Pedra : MonoBehaviour
{
    public float velocidadeDaPedra = 5f;
    public int dano = 10;

    private float direcao;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        if (rb2D == null)
        {
            Debug.LogError("Rigidbody2D não encontrado na pedra!");
        }
    }
    void Update()
    {
        // Move a pedra na direção do Golem
        rb2D.velocity = new Vector2(direcao * velocidadeDaPedra, rb2D.velocity.y);
        Destroy(gameObject, 7.0f);
    }
    public void DefinirDirecao(float escalaXGolem)
    {
        // Determina a direção com base na escala X do Golem
        direcao = escalaXGolem > 0 ? -1f : 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se colidir com um jogador, causa dano e destroi a pedra
        if (other.CompareTag("Player"))
        {
            ControleDeVida controleDeVida = other.GetComponent<ControleDeVida>();

            if (controleDeVida != null)
            {
                controleDeVida.ReceberDano(dano);
            }

            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    
}