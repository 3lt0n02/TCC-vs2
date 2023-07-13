using UnityEngine;

public class MoverPlataforma : MonoBehaviour
{
    public GameObject plataforma;
    public float velocidade = 5f; 

    private bool subindo = false; 

    private void Update()
    {
        if (subindo)
        {
            plataforma.transform.Translate(Vector3.up * velocidade * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            subindo = true;
        }
    }
}
