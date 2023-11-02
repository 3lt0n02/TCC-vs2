using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cenarioInfinito : MonoBehaviour
{
    public float velocidadeDoCenario;
    
    void Update()
    {
        Vector2 deslocamento = new Vector2(Time.time * velocidadeDoCenario, 0);
        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
    }
}
