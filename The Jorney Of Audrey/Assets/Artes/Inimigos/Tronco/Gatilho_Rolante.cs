using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatilho_Rolante : MonoBehaviour
{
    public GameObject Rolante;
    private bool _estaPressionado;
    void Start()
    {
       Rolante.SetActive(false);
        _estaPressionado = false;
    }

    
    void Update()
    {
        if (Rolante != null)
        {
            if (_estaPressionado)
            {
                Rolante.SetActive(true);
            }
        }
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _estaPressionado = true;
        }
    }
}
