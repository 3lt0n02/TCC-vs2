using UnityEngine;

public class MovimentarPersonagem : MonoBehaviour
{
    public float velocidade = 5f; // Velocidade de movimento

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        Vector2 direcaoMovimento = new Vector2(movimentoHorizontal, 0f);
        Vector2 velocidadeMovimento = direcaoMovimento * velocidade;

        rb2D.velocity = velocidadeMovimento;
    }
}
