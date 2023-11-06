using UnityEngine;

namespace Codigos.Interface
{
    public class ControleGamerOver : MonoBehaviour
    {
        public GameObject gameOverPanel; // Renomeado para gameOverPanel
        private bool isGameOver = false;

        
        void Start()
        {
            gameOverPanel.SetActive(false); // Desative o painel de game over no início.
        }

        public void AtivarGameOver()
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            isGameOver = true;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            gameOverPanel.SetActive(false);
            isGameOver = false;
        }

    }

    
}
