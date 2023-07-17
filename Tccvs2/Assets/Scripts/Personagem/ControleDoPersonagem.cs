using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControleDoPersonagem : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    // sistema de vida
    public BarraDeVida barra;
    public float vida;
    
    
   

    private Rigidbody2D rig;
    private bool estaNoChao;

    void Start()
    {
        
        barra.ColocarVidaMaxima(vida); 
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       move(); 
       Jump();
       Morte();
    }

    void move()
    {
        //movimentação
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }
    void Jump()
    {
        // execução do pulo
        if (estaNoChao && Input.GetButtonDown("Jump"))
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            estaNoChao = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // condisao para pular
        if (collision.gameObject.CompareTag("Grond"))
            {
                estaNoChao = true;
            }
            
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

