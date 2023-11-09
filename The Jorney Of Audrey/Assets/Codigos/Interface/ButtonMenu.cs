using UnityEngine;

namespace Codigos.Interface
{
    internal class ButtonMenu : MonoBehaviour
    {
   
        public void Reiniciar()
        {
            gamemanager.instance.CarregarFaseMorreu();
        }
        public void Menu()
        {
            gamemanager.instance.Menu();
        }
    }
}
