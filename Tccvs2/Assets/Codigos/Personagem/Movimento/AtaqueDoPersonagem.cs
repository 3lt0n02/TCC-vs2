using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueDoPersonagem : MonoBehaviour
{
    [Header ("variaveis de Ataque")]
    public Transform ataqueCheck;
    public float raioAtaque;
    public LayerMask layerinimigo;
    public float timeNextataque;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void Flip()
    {
        ataqueCheck.localPosition = new Vector2(-ataqueCheck.localPosition.x, ataqueCheck.localPosition.y);
    }
}