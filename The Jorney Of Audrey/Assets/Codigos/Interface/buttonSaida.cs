using System;
using UnityEngine;
using UnityEngine.UI;

namespace Codigos.Interface
{
    public class buttonSaida : MonoBehaviour
    {
        public Button _Button;

        private void Update()
        {
            _Button.onClick.AddListener(saida);
        }

        public void saida()
        {
            gamemanager.instance.saida();
        }
    }
}
