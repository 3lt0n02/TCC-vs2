using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    private Rigidbody2D rg;
    private float velocidade = 25.7f;

    //private bool taNaPLataforma;
    //public Transform detector;
    //public LayerMask oQueEPlataforma;

    public bool vaisubir;

    void Start()
    {
       rg = GetComponent<Rigidbody2D>(); 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        rg.bodyType = RigidbodyType2D.Dynamic;
        if(collision.gameObject.CompareTag("plataforma") && Input.GetButtonDown("subir"))
        {
            rg.bodyType = RigidbodyType2D.Dynamic;
            rg.velocity = Vector2.up * velocidade;
        }
    }

    void Update()
    {

    }

    
}
