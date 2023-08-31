using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControleDoPersonagem : MonoBehaviour
{
    [Header ("variaveis de Movimento")]
    public float forsaDoPulo;
    // variaveis de controle do pulo
    public LayerMask chao;
    public Transform oQueEhChao;
    private bool taNochao;
    private int puloExtra = 1;

    [Header ("variaveis do sitema de Vida")]
    public BarraDeVida barra;
    public float vida;
    
    // variavel do rigidbody2D do personagem
    private Rigidbody2D rig;
    

    void Start()
    {
        
        barra.ColocarVidaMaxima(vida); 
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        taNochao = Physics2D.OverlapCircle(oQueEhChao.position, 0.1f, chao);
        
        if(Input.GetButtonDown("Jump") && taNochao == true)
        {
            rig.velocity = Vector2.up * forsaDoPulo;
        }
        if(Input.GetButtonDown("Jump") && taNochao == false && puloExtra > 0)
        {
            rig.velocity = Vector2.up * forsaDoPulo;
            puloExtra--;
        }
        if(taNochao)
        {
            puloExtra = 1;
        }
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

