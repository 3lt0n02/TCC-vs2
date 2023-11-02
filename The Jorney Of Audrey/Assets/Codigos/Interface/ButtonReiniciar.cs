using UnityEngine;

namespace Codigos.Interface
{
    public class ButtonReiniciar : MonoBehaviour
    {
        public void Reiniciar()
        {
            gamemanager.instace.RecarregarCenaAnterior();
        }

    }
}
