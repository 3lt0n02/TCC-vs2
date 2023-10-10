using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platafoma_Subir_E_Descer : MonoBehaviour
{
    private bool moverParaBaixo = true;

    public Transform pontoA;
    public Transform pontoB;

    public float velocidade;
    
    void Update()
    {
        if (transform.position.y > pontoA.position.y)
        {
            moverParaBaixo = true;
        }

        if (transform.position.y < pontoB.position.y)
        {
            moverParaBaixo = false;
        }

        if (moverParaBaixo)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);
        }
    }
}
