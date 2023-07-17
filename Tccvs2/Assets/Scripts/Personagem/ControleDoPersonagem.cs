using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoPersonagem : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rig;
    private bool estaNoChao;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       move(); 
       Jump();
    }

    void move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }
    void Jump()
    {
        if (estaNoChao && Input.GetButtonDown("Jump"))
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            estaNoChao = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grond"))
            {
                estaNoChao = true;
            }
            
        if (collision.gameObject.CompareTag("ObjetoPai"))
            {
                transform.SetParent(collision.transform);
            }
    }

}

