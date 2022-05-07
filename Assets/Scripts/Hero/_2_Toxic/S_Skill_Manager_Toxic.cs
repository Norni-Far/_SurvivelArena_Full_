using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Skill_Manager_Toxic : MonoBehaviour
{
    [SerializeField] private S_Shot_forHero_1_Atilus S_Shot;
    public List<int> skill_lvl = new List<int>(10);



    public void ExploreSkill(int number)
    {


        skill_lvl[number]++;
        switch (number)
        {
            case 0:
                ExploreSkill_1(number);
                break;
            case 1:
              //  ExploreSkill_2(number);
                break;
            case 2:
                //ExploreSkill_3(number);
                break;
            case 3:
               // ExploreSkill_4(number);
                break;
            case 4:
               // ExploreSkill_5(number);
                break;
            case 5:
              //  ExploreSkill_6(number);
                break;
            case 6:
       //         ExploreSkill_7(number);
                break;
        }
    }


    private void ExploreSkill_1(int number)
    {
        switch (skill_lvl[number])
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

}
