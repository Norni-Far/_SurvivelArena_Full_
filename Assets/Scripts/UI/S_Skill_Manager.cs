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
            case 2:
                ExploreSkill_3();
                break;
        }
    }


    private void ExploreSkill_1()
    {
        switch (skill_lvl[0])
        {
            case 1:
                S_Shot.skill_active[0] = true;
                S_Shot.amount_shots++; //несколько выстрелов подряд
                break;
            case 2:
                S_Shot.amount_shots++;
                S_Shot.damage += 5;
                break;
            case 3:
                S_Shot.amount_shots++;
                S_Shot.pauseShot = S_Shot.pauseShot * 0.7f;
                break;
        }
    }

    private void ExploreSkill_2()
    {
        switch (skill_lvl[1])
        {
            case 1:
                S_Shot.skill_active[1] = true;
                transform.GetComponent<S_Many_Shots>().lvl_many_shots ++;
                break;
            case 2:
                transform.GetComponent<S_Many_Shots>().damage += 5;
                break;
            case 3:
                transform.GetComponent<S_Many_Shots>().damage += 10;
                break;
            case 4:
                transform.GetComponent<S_Many_Shots>().lvl_many_shots++;
                break;
        }
    }
    private void ExploreSkill_3()
    {
        switch (skill_lvl[1])
        {
            case 1:
                S_Shot.numberOfBullet = 1;
                break;
            case 2:
                transform.GetComponent<S_Many_Shots>().damage += 5;
                break;
            case 3:
                transform.GetComponent<S_Many_Shots>().damage += 10;
                break;
            case 4:
                transform.GetComponent<S_Many_Shots>().lvl_many_shots++;
                break;
        }
    }
}
