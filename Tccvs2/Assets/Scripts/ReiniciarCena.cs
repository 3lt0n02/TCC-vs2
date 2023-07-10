using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarCena : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Reiniciar();
        }
    }

    private void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
