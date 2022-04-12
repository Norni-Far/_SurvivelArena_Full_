using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Skill_Manager : MonoBehaviour
{
    public bool [] skill_active = new bool [20];
    [SerializeField] private S_Shot S_Shot;


    public void ExploreSkill( int number)   
    {
        switch (number)
        {
            case 1:
                S_Shot.amount_shots++;
                break;
        }
    }
}
