using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueDoJogador : MonoBehaviour
{
    private bool atacando;
    public Animator animator;

    public Transform ataquePonto;
    public float ataqueRange= 0.5f;
    public LayerMask inimigoLayer;
    
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        atacando = Input.GetButtonDown("Fire1");
        if (atacando == true)
        {
            AtaqueBasico();
        }
    }

    void AtaqueBasico()
    {
        // animação
        
        // criar o Range de ataque no inimigo
        Collider2D[] HitInimigo = Physics2D.OverlapCircleAll(ataquePonto.position, ataqueRange, inimigoLayer);
        foreach (Collider2D inimigo in HitInimigo)
        {
            inimigo.GetComponent<MoteDoInimigo>().DanoNoImigo(100);
        }
        
        //dano no inimigo

    }
}
