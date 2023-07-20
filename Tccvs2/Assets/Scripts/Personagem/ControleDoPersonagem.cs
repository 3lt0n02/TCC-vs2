using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControleDoPersonagem : MonoBehaviour
{
    [Header ("variaveis de Movimento")]
    public float speed;
    public float jumpForce;
    private int puloExtra = 1;
    public bool estaNoChao;
    public Transform detectaChao;
    public LayerMask oQueEchao;
    
    [Header ("variaveis do sitema de Vida")]
    public BarraDeVida barra;
    //public Tronco tronco;
    public float vida;
    public GameObject bolaVerde;
    
    
   

    private Rigidbody2D rig;
    

    void Start()
    {
        
        barra.ColocarVidaMaxima(vida); 
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       estaNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.1f, oQueEchao);
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
        if (Input.GetButtonDown("Jump") && estaNoChao == true)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
        }
        if (Input.GetButtonDown("Jump") && estaNoChao == false && puloExtra > 0)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            puloExtra--;
        }
        if(estaNoChao)
        {
            puloExtra = puloExtra + 1;
        }
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
        if (collision.gameObject.CompareTag("Gatilho"))
            {    
                Tronco script = bolaVerde.GetComponent<Tronco>();
                //Rigidbody2D rg = bolaVerde.GetComponent<Rigidbody2D>();
                script.move();
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

