using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    private float tamanho;
    private float posisaoInicial;
    
    public float efeitoParallax;

    public GameObject cameraPlayer;



    void Start()
    {
        posisaoInicial = transform.position.x;
        tamanho = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cameraPlayer.transform.position.x * (1 - efeitoParallax));

        float distancia = (cameraPlayer.transform.position.x * efeitoParallax);

        transform.position = new Vector3(posisaoInicial + distancia, transform.position.y, transform.position.z);

        if (temp > posisaoInicial + tamanho)
        {
            posisaoInicial += tamanho;
        }
        else if (temp < posisaoInicial - tamanho)
        {
            posisaoInicial -= tamanho;
        }
    }
}
