using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vazio : MonoBehaviour
{
     
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerPrefs.SetString("faseMorreu",SceneManager.GetActiveScene().name);
            gamemanager.instace.GameOver();
        }
            
    }
}
