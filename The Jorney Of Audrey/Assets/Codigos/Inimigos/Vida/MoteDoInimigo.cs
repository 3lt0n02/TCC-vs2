using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoteDoInimigo : MonoBehaviour
{
    public float vidaAtual = 100;

    public void DanoNoImigo(int dano)
    {
        vidaAtual -= dano;
        if (vidaAtual <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
