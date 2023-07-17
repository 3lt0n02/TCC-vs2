using UnityEngine;

public class MovimentoAutomatico : MonoBehaviour
{
    [Header ("variaveis de movimento")]
    private Vector3 direcaoMovimento = Vector3.left; // Direcao do movimento
    public float velocidade = 5f; // Velocidade de movimento

    public void Update()
    { 
        //movimentacao do objeto
        transform.Translate(direcaoMovimento * velocidade * Time.deltaTime);  
    } 
}
    
