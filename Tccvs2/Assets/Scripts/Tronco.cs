using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tronco : MonoBehaviour
{
    private Rigidbody2D rg;
    public float velocidade;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
    public void move()
    {
        //rg.velocity = Vector2.left * velocidade;
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }
}
