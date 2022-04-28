using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Buy_Skill : MonoBehaviour
{
    public delegate void delegats(int number);
    public event delegats event_skillForHero;
    [SerializeField] GameObject skills_panel;

    [SerializeField] private int[] skill_lvl = new int[10];
    public void BuySkill_1()
    {
        event_skillForHero?.Invoke(0);
        transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
        skills_panel.GetComponent<S_Skill_Add>().skill_lvl[0]++;
    }
    public void BuySkill_2()
    {
        event_skillForHero?.Invoke(1);
        transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
        skills_panel.GetComponent<S_Skill_Add>().skill_lvl[1]++;

    }
    public void BuySkill_3()
    {
        event_skillForHero?.Invoke(2);
        transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
        skills_panel.GetComponent<S_Skill_Add>().skill_lvl[2]++;

    }
    public void BuySkill_4()
    {
        event_skillForHero?.Invoke(3);
        transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
        skills_panel.GetComponent<S_Skill_Add>().skill_lvl[3]++;

    }
    public void BuySkill_5()
    {
        event_skillForHero?.Invoke(4);
        transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
        skills_panel.GetComponent<S_Skill_Add>().skill_lvl[4]++;

    }
    public void BuySkill_6()
    {
        event_skillForHero?.Invoke(5);
        transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
        skills_panel.GetComponent<S_Skill_Add>().skill_lvl[5]++;

    }
    public void BuySkill_7()
    {
        event_skillForHero?.Invoke(6);
        transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
        skills_panel.GetComponent<S_Skill_Add>().skill_lvl[6]++;

    }
    public void BuySkill_8()
    {
        event_skillForHero?.Invoke(7);
        transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
        skills_panel.GetComponent<S_Skill_Add>().skill_lvl[7]++;

    }
    public void BuySkill_9()
    {
        event_skillForHero?.Invoke(8);
        transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
        skills_panel.GetComponent<S_Skill_Add>().skill_lvl[8]++;

    }
    public void BuySkill_10()
    {
        event_skillForHero?.Invoke(9);
        transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
        skills_panel.GetComponent<S_Skill_Add>().skill_lvl[9]++;

    }
}
