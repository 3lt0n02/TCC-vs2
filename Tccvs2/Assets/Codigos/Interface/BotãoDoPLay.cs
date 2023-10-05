using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BotãoDoPLay : MonoBehaviour
{

    public void clicarNoBotão()
    {
        gamemanager.intance.DarPlayNoJogo();
    }
}
