using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoteDoInimigo : MonoBehaviour
{
    private float vidaAtual = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DanoNoImigo(int dano)
    {
        vidaAtual -= dano;
        if (vidaAtual <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
