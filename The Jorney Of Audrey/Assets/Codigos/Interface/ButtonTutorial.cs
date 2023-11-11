
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTutorial : MonoBehaviour
{
   [SerializeField]private Button _button;

   private void Start()
   {
      _button.onClick.AddListener(Tutorial);
   }

   private void Tutorial()
   {
      gamemanager.instance.Tutorial();
   }
}
