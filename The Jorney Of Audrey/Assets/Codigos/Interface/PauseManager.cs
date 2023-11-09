using UnityEngine;

namespace Codigos.Interface
{
    public class PauseManager : MonoBehaviour
    {
        public GameObject pausePanel;

        void Start()
        {
            pausePanel.SetActive(false);
        }
         
        public void PauseGame()
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
     
        public void ResumeGame()
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
}