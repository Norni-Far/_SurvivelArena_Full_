using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Subscribes : MonoBehaviour
{
    [SerializeField] private S_Buy_Skill s_Buy_Skill;
    [SerializeField] private GameObject S_Skill_Panel_Active;
    [SerializeField] private S_Lvl_Slider s_Lvl_Slider;
    [SerializeField] private UI_Manager UI_Manager;


    [HideInInspector] public GameObject heroObject;

    public void StartSubscribes()
    {
        s_Lvl_Slider.event_lvlup += UI_Manager.LvlUpPanelActeve;
    }

    public void Hero_Subscribes()
    {
        // ��� ���������� ����� ������
        heroObject.GetComponent<S_InformationAboutHero>().S_ExpirianceForHero.event_SendExpiriance += UI_Manager.GiveExpirienceFromHero;
        // ��� ������ �� �� ������
        heroObject.GetComponent<S_Herohealth>().event_deadHero += UI_Manager.TextDead;


        // ��������� ����� ����������� 
        s_Buy_Skill.event_skillForHero += heroObject.GetComponent<S_Skill_Manager>().ExploreSkill;
        s_Buy_Skill.event_skillForHero += S_Skill_Panel_Active.GetComponent<S_skill_panel_active>().AddSkill;
    }



}
