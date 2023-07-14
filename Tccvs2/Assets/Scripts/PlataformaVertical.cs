using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    private Rigidbody2D rg;
    public float velocidade = 28f;

    private bool taNaPLataforma;
    public Transform detector;
    public LayerMask oQueEPlataforma;

    public bool vaisubir;

    void Start()
    {
       rg = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        taNaPLataforma = Physics2D.OverlapCircle(detector.position, 0.2f, oQueEPlataforma);
        if(Input.GetButtonDown("subir") && taNaPLataforma == true)
        {
            rg.velocity = Vector2.up * velocidade;
        }
    }

    
}
