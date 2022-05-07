using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Subscribes : MonoBehaviour
{
    [SerializeField] private S_Buy_Skill s_Buy_Skill;
    [SerializeField] private GameObject[] S_Skill_Panel_Active;
    [SerializeField] private S_Lvl_Slider s_Lvl_Slider;
    [SerializeField] private UI_Manager UI_Manager;
    public int numberHero;

    [HideInInspector] public GameObject heroObject;

    public void StartSubscribes()
    {
        s_Lvl_Slider.event_lvlup += UI_Manager.LvlUpPanelActeve;
    }

    public void Hero_Subscribes(int numOfHero)
    {
        numberHero = numOfHero;

        // общее для героев 
        // для подбирания опыта героем
        heroObject.GetComponent<S_InformationAboutHero>().S_ExpirianceForHero.event_SendExpiriance += UI_Manager.GiveExpirienceFromHero;
        // для показа панели смерти героя 
        heroObject.GetComponent<S_Herohealth>().event_deadHero += UI_Manager.TextDead;

        // индивидуально для героев
        switch (numberHero)
        {
            case 0:
                // добавляет новую способность 
                s_Buy_Skill.event_skillForHero += heroObject.GetComponent<S_Skill_Manager_Atilus>().ExploreSkill;
                s_Buy_Skill.event_skillForHero += S_Skill_Panel_Active[numberHero].GetComponent<S_skill_panel_active>().AddSkill;
                break;

            case 1:
                s_Buy_Skill.event_skillForHero += heroObject.GetComponent<S_Skill_Manager_Toxic>().ExploreSkill;
                s_Buy_Skill.event_skillForHero += S_Skill_Panel_Active[numberHero].GetComponent<S_skill_panel_active>().AddSkill;
                break;

            case 2:
                break;

            case 3:
                break;
        }

    }



}
