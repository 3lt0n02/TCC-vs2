using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Final_Da_Fase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag(("Player")))
        {
            Debug.Log("Filanalizou a fase");
            SceneManager.LoadScene("MenuInicial");
        }
    }
    
        
}
