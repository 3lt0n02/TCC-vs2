using UnityEngine;

public class MovimentoOrc : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    public float velocidade;
   

    private bool moverParaEsquerda = true;
    private Vector3 _olharDireita;
    private Vector3 _olharEsquerda;

    public Animator _Animator;

    private void Start()
    {
        _olharDireita = transform.localScale;
        _olharEsquerda = transform.localScale;
        _olharEsquerda.x = _olharEsquerda.x * -1;
    }

    private void Update()
    {
        Movimentar();
    }

    private void Movimentar()
    {
        if (transform.position.x > pontoA.position.x)
        {
            moverParaEsquerda = true;
        }

        if (transform.position.x < pontoB.position.x)
        {
            moverParaEsquerda = false;
        }

        if (moverParaEsquerda)
        {
            _Animator.SetBool("Andado", true);
            transform.Translate(Vector2.left * (velocidade * Time.deltaTime));
            // Aplicar escala invertida para olhar para a esquerda.
            transform.localScale = _olharEsquerda;
        }
        else
        {
            _Animator.SetBool("Andado", true);
            transform.Translate(Vector2.right * (velocidade * Time.deltaTime));
            // Restaurar a escala original para olhar para a direita.
            transform.localScale = _olharDireita;
        }
    }
}