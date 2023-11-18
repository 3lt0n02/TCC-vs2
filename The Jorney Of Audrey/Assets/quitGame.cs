using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void quitGameApp()
    {
        gamemanager.instance.saida();
    }
}
