using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Plant : MonoBehaviour
{
     public GameObject objetoParaInstanciar;
     public Transform pontoDeInstancia;
     
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    
    void disparo()
    {
    
     Instantiate(objetoParaInstanciar, pontoDeInstancia.position, pontoDeInstancia.rotation);    
    
    }
}
