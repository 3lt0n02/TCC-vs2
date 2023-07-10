using UnityEngine;

public class SeguirPersonagem : MonoBehaviour
{
    public Transform personagem;
    public Vector3 offset;

    void Update()
    {
        transform.position = personagem.position + offset;
    }
}
