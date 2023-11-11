using UnityEngine;
using UnityEngine.UI;

namespace Codigos.Interface
{
    public class ButtonFaseUm : MonoBehaviour
    {
        [SerializeField] private Button _button;
        void Start()
        {
            _button.onClick.AddListener(faseUm);
        
        }
        void faseUm()
        {
            gamemanager.instance.fase1();
        }
    }
}
