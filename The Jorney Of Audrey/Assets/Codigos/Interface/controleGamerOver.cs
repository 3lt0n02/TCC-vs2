using UnityEngine;
using UnityEngine.Serialization;

namespace Codigos.Interface
{
    public class ControleGamerOver : MonoBehaviour
    {
        public GameObject gameOverPanel; // Renomeado para gameOverPanel

        [field: FormerlySerializedAs("_isGameOver")]
        [field: SerializeField]
        public bool IsGameOver { get; private set; } = false;


        void Start()
        {
            gameOverPanel.SetActive(false); // Desative o painel de game over no início.
            IsGameOver = false;
        }

        public void AtivarGameOver()
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            IsGameOver = true;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            gameOverPanel.SetActive(false);
            IsGameOver = false;
        }

    }

    
}
