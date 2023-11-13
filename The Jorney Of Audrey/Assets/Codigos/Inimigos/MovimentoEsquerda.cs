using UnityEngine;

public class MovimentoEsquerda : MonoBehaviour
{
    public float velocidade = 5.0f; // Velocidade de movimento para a esquerda.

    private Rigidbody2D rb;
    public int dano = 20;
    public float tempoDeVida = 5.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Mover o objeto para a esquerda (velocidade negativa).
        rb.velocity = new Vector2(-velocidade, rb.velocity.y);
        Destroy(gameObject, tempoDeVida);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControleDeVida controleDeVida = collision.GetComponent<ControleDeVida>();

            if (controleDeVida != null)
            {
                controleDeVida.ReceberDano(dano);
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
            
        }
    }
}