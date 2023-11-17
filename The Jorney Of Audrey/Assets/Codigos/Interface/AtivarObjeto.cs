using System;
using UnityEngine;

namespace Codigos.Interface
{
    public class AtivarObjeto : MonoBehaviour
    {
        public GameObject objeto;
        
        void Start()
        {
            objeto.SetActive(false);
        
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                objeto.SetActive(true);
            }
        }
    }
}
