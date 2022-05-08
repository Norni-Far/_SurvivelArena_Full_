using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Skill_Manager_Toxic : MonoBehaviour
{
    public List<int> skill_lvl = new List<int>(10);
    private S_Toxin_spawn  S_Toxin_spawn;
    private S_Cloud_Toxic S_Cloud_Toxic;
    private S_Infect S_Infect;

    private void Start()
    {
        S_Toxin_spawn = GetComponent<S_Toxin_spawn>();
        S_Cloud_Toxic = GetComponent<S_Cloud_Toxic>();
        S_Infect = GetComponent<S_Infect>();
    }
    public void ExploreSkill(int number)
    {


        skill_lvl[number]++;
        switch (number)
        {
            case 0:
                ExploreSkill_1(number);
                break;
            case 1:
                ExploreSkill_2(number);
                break;
            case 2:
                ExploreSkill_3(number);
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


    private void ExploreSkill_1(int number) // toxin токсиновый дождь
    {
        switch (skill_lvl[number])
        {
            case 1:
                S_Toxin_spawn.enabled = true;
                break;
            case 2:
                S_Toxin_spawn.damage += 3;
                break;
            case 3:
                S_Toxin_spawn.damage += 10;
                break;
        }
    }

    private void ExploreSkill_2(int number) // cloud токсиновое облако
    {
        switch (skill_lvl[number])
        {
            case 1:
                S_Cloud_Toxic.enabled = true;
                break;
            case 2:
                S_Cloud_Toxic.damage += 5;
                break;
            case 3:
                S_Cloud_Toxic.damage += 15;
                break;
            case 4:
                S_Cloud_Toxic.scale = 0.7f;
                S_Cloud_Toxic.couldown -= 5;
                break;
            case 5:
                S_Cloud_Toxic.couldown = 2000000f; // делает облако бесконечным
                S_Cloud_Toxic.timeLife = 2000000f;
                break;
        }
    }
    private void ExploreSkill_3(int number) // cloud токсиновое облако
    {
        switch (skill_lvl[number])
        {
            case 1:
                S_Infect.treatForHero += 2;
                S_Toxin_spawn.treatForHero += 2;
                S_Cloud_Toxic.treatForHero += 2;
                break;
            case 2:
                S_Infect.treatForHero += 5;
                S_Toxin_spawn.treatForHero += 5;
                S_Cloud_Toxic.treatForHero += 5;
                break;
            case 3:
                S_Infect.treatForHero += 10;
                S_Toxin_spawn.treatForHero += 10;
                S_Cloud_Toxic.treatForHero += 10;
                break;
            
        }
    }

}
