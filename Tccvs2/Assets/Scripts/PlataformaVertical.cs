using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    private Rigidbody2D rg;
    private float velocidade = 25.7f;
    private bool estaNaPlataforma = false;
    public bool vaiSubir;

    void Start()
    {
       rg = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        plataforma();

    }

    void plataforma()
    {
        if(estaNaPlataforma && Input.GetButtonDown("subir") && vaiSubir == true)
        {
            rg.bodyType = RigidbodyType2D.Dynamic;
            rg.velocity = Vector2.up * velocidade;
        }
        
        if(estaNaPlataforma && Input.GetButtonDown("subir") && vaiSubir == false)
        {
            velocidade = 1f;
            rg.bodyType = RigidbodyType2D.Dynamic;
            rg.velocity = Vector2.down * velocidade;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estaNaPlataforma = true;

        }
    
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        estaNaPlataforma = false;
    }
}
