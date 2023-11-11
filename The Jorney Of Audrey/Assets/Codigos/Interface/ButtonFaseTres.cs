using UnityEngine;
using UnityEngine.UI;
namespace Codigos.Interface
{
    public class ButtonFaseTres : MonoBehaviour
    {
        [SerializeField] private Button _button;
        void Start()
        {
            _button.onClick.AddListener(fasetres);
        
        }
        void fasetres()
        {
            gamemanager.instance.fase3();
        }
    }
}
