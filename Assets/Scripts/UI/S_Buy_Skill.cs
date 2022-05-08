using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Buy_Skill : MonoBehaviour
{
    public delegate void delegats(int number);
    public event delegats event_skillForHero;
    [SerializeField] GameObject [] skills_panel;
    [HideInInspector] public int numberHero;
    [SerializeField] private int[] skill_lvl = new int[10];
    public void BuySkill(int numberSkills)
    {
        switch (numberHero)
        {
            case 0:
                skills_panel[numberHero].GetComponent<S_Skill_Add_Atilus>().skill_lvl[numberSkills]++;
                event_skillForHero?.Invoke(numberSkills);
                transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
                break;
            case 1:
                skills_panel[numberHero].GetComponent<S_Skill_Add_Toxic>().skill_lvl[numberSkills]++;
                event_skillForHero?.Invoke(numberSkills);
                transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
                break;
            case 2:
           //     skills_panel[numberHero].GetComponent<S_Skill_Add_Atilus>().skill_lvl[numberSkills]++;
                event_skillForHero?.Invoke(numberSkills);
                transform.GetComponent<UI_Manager>().LvlUpPanelActeve();
                break;
        }

       
    }
}
