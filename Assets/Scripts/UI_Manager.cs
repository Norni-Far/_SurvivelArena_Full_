using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private S_Lvl_Slider S_Lvl_Slider;

   
    public void GiveExporoenceFromGero(int exp)
    {
        S_Lvl_Slider.Give_Exp(exp);
    }
}
