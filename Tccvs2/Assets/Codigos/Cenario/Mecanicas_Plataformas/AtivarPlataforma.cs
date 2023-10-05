using UnityEngine;

public class AtivarPlataforma : MonoBehaviour
{
    [Header ("variaveis de controle de plataformas")]
    public GameObject plataforma;

    private bool estaPressionado;

    void Start()
    {
        plataforma.SetActive(false);
    }

    void Update()
    {
        if (estaPressionado)
        {
            plataforma.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            estaPressionado = true;
        }
    }
}
