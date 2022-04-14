using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Lvl_Slider : MonoBehaviour
{
    public delegate void delegats();
    public event delegats event_lvlup;

    [SerializeField] private int exp;
    public int lvl;
    [SerializeField] private int max_exp;
    private Slider exp_slider;

    private void Start()
    {
        
        exp_slider = GetComponent<Slider>();
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
            event_lvlup?.Invoke();
            
        }


        exp_slider.value = exp;
    }
}
