using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControleDoPersonagem : MonoBehaviour
{
    [Header ("variaveis do sitema de Vida")]
    public BarraDeVida barra;
    public float vida;
    
    // variavel do rigidbody2D do personagem
    void Start()
    {
        //barra.ColocarVidaMaxima(vida);
    }

    void Update()
    {
        Morte();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {       
        // grudando na plataforma
        if (collision.gameObject.CompareTag("ObjetoPai"))
            {
                transform.SetParent(collision.transform);
            }
        // recebendo dano do inimigo
        if (collision.gameObject.CompareTag("Inimigo"))
            {
                vida -= 10.0f;
                barra.alterarVida(vida);
            }
    }
    void Morte()
    {
        if(vida <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}

