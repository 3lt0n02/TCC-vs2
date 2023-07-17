using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoTerrestre : MonoBehaviour
{
    public float velocidade;
    public float distancia;

    private bool edireita = true;
    public Transform estaNoChao;

    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(Vector2.right* velocidade * Time.deltaTime);
        RaycastHit2D Chao = Physics2D.Raycast(estaNoChao.position, Vector2.down, distancia);

        if (Chao.collider == false)
        {
            if(edireita == true)
            {
                transform.eulerAngles = new Vector2(0, 0);
                edireita = false;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
                edireita = true;

            }
        }
    }
}
