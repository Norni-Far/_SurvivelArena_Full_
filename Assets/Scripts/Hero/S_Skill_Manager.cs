using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Skill_Manager : MonoBehaviour
{
    [SerializeField] private S_Shot S_Shot;


    public void ExploreSkill( int number)   
    {
        switch (number)
        {
            case 0:
                S_Shot.skill_active[0] = true;
                S_Shot.amount_shots++; //несколько выстрелов подряд
                break;
            case 1:
                S_Shot.skill_active[1] = true;
                break;
        }
    }
}
