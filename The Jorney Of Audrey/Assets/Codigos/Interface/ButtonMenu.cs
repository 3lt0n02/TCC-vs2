using UnityEngine;

namespace Codigos.Interface
{
    internal class ButtonMenu : MonoBehaviour
    {
   
        public void Reiniciar()
        {
            gamemanager.instace.CarregarFaseMorreu();
        }
        public void Menu()
        {
            gamemanager.instace.FinalizarFase();
        }
    }
}
