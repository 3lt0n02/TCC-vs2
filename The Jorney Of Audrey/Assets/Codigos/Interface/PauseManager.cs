using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
     
         private bool isPaused;
     
         void Start()
         {
             pausePanel.SetActive(false);
             isPaused = false;
         }
         
         public void PauseGame()
         {
             Time.timeScale = 0;
             pausePanel.SetActive(true);
             isPaused = true;
         }
     
         public void ResumeGame()
         {
             Time.timeScale = 1;
             pausePanel.SetActive(false);
             isPaused = false;
         }
}