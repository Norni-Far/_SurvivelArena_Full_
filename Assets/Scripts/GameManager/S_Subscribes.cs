using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Subscribes : MonoBehaviour
{
    [SerializeField] private S_Lvl_Slider s_Lvl_Slider;
    [SerializeField] private UI_Manager UI_Manager;


    [HideInInspector] public GameObject heroObject;

    public void StartSubscribes()
    {
        s_Lvl_Slider.event_lvlup += UI_Manager.LvlUpPanelActeve;
    }

    public void Hero_Subscribes()
    {
        // для подбирания опыта героем
        heroObject.GetComponent<S_InformationAboutHero>().S_ExpirianceForHero.event_SendExpiriance += UI_Manager.GiveExporoenceFromGero;
        // для показа хп на экране
        heroObject.GetComponent<S_HeroHealth>().event_deadHero += UI_Manager.TextDead;

    }

}
