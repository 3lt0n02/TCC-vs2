using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class plataformaHorizontal : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade;
    


    private bool moverParaEsquerda = true;

    void Update()
    {
        transform.localScale = new Vector3(1, 1, 1);
       
        if (transform.position.x > pontoA.position.x)
        {
            moverParaEsquerda = true;
        }

        if (transform.position.x < pontoB.position.x)
        {
            moverParaEsquerda = false;
        }

        if (moverParaEsquerda)
        {
            transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player")) col.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")) other.transform.SetParent(null);
    }
}
