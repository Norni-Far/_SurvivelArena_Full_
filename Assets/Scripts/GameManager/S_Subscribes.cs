using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Subscribes : MonoBehaviour
{
    [SerializeField] private S_Buy_Skill s_Buy_Skill;
    [SerializeField] private S_Skill_Manager s_Skill_Manager;
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


        // добавляет новую способность 
        s_Buy_Skill.event_skillForHero += s_Skill_Manager.ExploreSkill;
    }



}
