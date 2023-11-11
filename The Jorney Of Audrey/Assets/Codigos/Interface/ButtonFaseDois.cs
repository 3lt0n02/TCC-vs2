using UnityEngine;
using UnityEngine.UI;



namespace Codigos.Interface
{
    public class ButtonFaseDois : MonoBehaviour
    {
        [SerializeField] private Button _button;
        void Start()
        {
            _button.onClick.AddListener(fasedois);
        
        }
        void fasedois()
        {
            gamemanager.instance.fase2();
        }
    }
}
