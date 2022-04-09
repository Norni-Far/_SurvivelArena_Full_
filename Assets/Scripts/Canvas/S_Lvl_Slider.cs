using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Lvl_Slider : MonoBehaviour
{
    private int exp;
    public int lvl;
    private int max_exp;
    public Slider exp_slider;

    private void Start()
    {
        exp_slider.value = exp;
        exp_slider.maxValue = max_exp;
    }


    public void Give_Exp(int exp_plus)
    {
        exp += exp_plus;

        if (exp >= max_exp)
        {
            exp -= max_exp;
            max_exp *= 2;
            exp_slider.maxValue = max_exp;
            lvl++;
        }
            

        exp_slider.value = exp;



    }
}
