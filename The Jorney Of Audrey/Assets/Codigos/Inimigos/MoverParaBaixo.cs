using UnityEngine;

public class MoverParaBaixo : MonoBehaviour
{
    public float velocidade; // Ajuste a velocidade conforme necessário.
    public int dano = 10; // dano do disparo

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Defina a velocidade vertical negativa para mover o objeto para baixo.
        rb.velocity = new Vector2(0, -velocidade);
        Destroy(gameObject, 5.0f);
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