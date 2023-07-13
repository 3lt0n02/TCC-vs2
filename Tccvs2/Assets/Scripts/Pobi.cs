using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pobi : MonoBehaviour
{
    public GameObject plataforma;
    public float velocidade;

    private bool estaPressionado = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(estaPressionado)
        {
            plataforma.transform.Translate(Vector3.up * velocidade * Time.deltaTime);
        }
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            estaPressionado = true;
        }
    }


}
