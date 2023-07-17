using UnityEngine;

public class MovimentoAutomatico : MonoBehaviour
{
    private Vector3 direcaoMovimento = Vector3.left; // Direcao do movimento
    public float velocidade = 5f; // Velocidade de movimento

    public void Update()
    { 
        //movimentação do objeto
        transform.Translate(direcaoMovimento * velocidade * Time.deltaTime);  
    } 
}
    
