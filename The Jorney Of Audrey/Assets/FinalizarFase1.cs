using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalizarFase1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Acabou a fase 1");
        gamemanager.instance.FinalizarFase1();
    }
}