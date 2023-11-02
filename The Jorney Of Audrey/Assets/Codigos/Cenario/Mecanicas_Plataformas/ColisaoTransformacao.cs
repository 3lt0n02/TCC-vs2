using UnityEngine;

public class ColisaoTransformacao : MonoBehaviour
{
    public GameObject objetoTransformado;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("plataforma"))
        {
            // Verifique se o objeto alvo tem um Rigidbody anexado.
            if (objetoTransformado.TryGetComponent(out Rigidbody rb))
            {
                // Faça o objeto alvo se tornar um filho do objeto transformado.
                objetoTransformado.transform.parent = transform;
                // Desative o Rigidbody do objeto alvo para que ele não afete a física.
                rb.isKinematic = true;
            }
        }
    }
}
