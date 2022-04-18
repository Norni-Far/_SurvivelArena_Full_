using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Skill_Manager : MonoBehaviour
{
    [SerializeField] private S_Shot S_Shot;
    public int[] skill_lvl = new int[10];
    

    public void ExploreSkill( int number)   
    {

        skill_lvl[number]++;
        switch (number)
        {
            case 0:
                ExploreSkill_1();
                break;
            case 1:
                ExploreSkill_2();
                break;
        }
    }


    private void ExploreSkill_1()
    {
        switch (skill_lvl[0])
        {
            case 1:
                S_Shot.skill_active[0] = true;
                S_Shot.amount_shots++; //��������� ��������� ������
                break;
            case 2:
                S_Shot.amount_shots++;
                S_Shot.damage += 5;
                break;
        }
    }

    private void ExploreSkill_2()
    {
        switch (skill_lvl[0])
        {
            case 1:
                S_Shot.skill_active[1] = true;
                break;
            case 2:
                S_Shot.damage += 5;
                break;
        }
    }
}
