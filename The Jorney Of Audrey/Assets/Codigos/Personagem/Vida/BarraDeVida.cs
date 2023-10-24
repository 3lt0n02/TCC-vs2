using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    [Header ("variaveis de controle da barra de vida")]
    public Slider slider;
    

   // função para alterá o valor da vida
   public void alterarVida(float vida)
   {
    slider.value = vida;
   }

   public void ColocarVidaMaxima(float vida)
   {
    slider.maxValue = vida;
    slider.value = vida;
   }


}
