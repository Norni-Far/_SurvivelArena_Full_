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
    }
    public void BuySkill_2()
    {
        event_skillForHero?.Invoke(1);
        transform.GetComponent<UI_Manager>().LvlUpPanelActeve();

    }
}
