using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContAniPLayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private MovimentarPersonagem player;

   
    void Update()
    {
        if (this.player.taNoChao)
        {
            float velocidadex = Mathf.Abs(this._rigidbody2D.velocity.x);
            if (velocidadex > 0)
            {
                this._animator.SetBool("andando", true);
            }
            else
            {
                this._animator.SetBool("andando", false);
            }
            
        }
        else
        {
            float velocidadey = this._rigidbody2D.velocity.y;
            if (velocidadey > 0 ) // ta pulando
            {
                this._animator.SetBool("pulando", true);
            }
            else
            {
                {
                    this._animator.SetBool("pulando", false);
                }
            }
        }
        

    }
}
