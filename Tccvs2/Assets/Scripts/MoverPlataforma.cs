using UnityEngine;

public class MoverPlataforma : MonoBehaviour
{
    public GameObject plataforma; // Referência ao objeto da plataforma
    public float velocidade = 5f; // Velocidade de movimento da plataforma

    private bool subindo = false; // Flag para indicar se a plataforma está subindo

    private void Update()
    {
        if (subindo)
        {
            // Mover a plataforma para cima
            plataforma.transform.Translate(Vector3.up * velocidade * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            subindo = true; // Ativar o movimento da plataforma quando colidir com o personagem
        }
    }
}
