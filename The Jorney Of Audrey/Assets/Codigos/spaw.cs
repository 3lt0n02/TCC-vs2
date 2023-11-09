using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaw : MonoBehaviour
{
    public GameObject player;
    public Transform spawLocal;
    void Start()
    {
        Instantiate(player, spawLocal.position, spawLocal.rotation);
    }
}
