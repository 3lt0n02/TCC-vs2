using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSubir : MonoBehaviour
{
    private Rigidbody2D rg;
    private bool estaNaPlataforma;
    public float velocidade;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
         if(estaNaPlataforma && Input.GetButtonDown("subir"))
        {
            rg.bodyType = RigidbodyType2D.Dynamic;
            rg.velocity = Vector2.up * velocidade;
        }  
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estaNaPlataforma = true;
        }
        if(collision.gameObject.CompareTag("Stop"))
        {
            rg.bodyType = RigidbodyType2D.Static;
        }
    
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        estaNaPlataforma = false;
    }
}
