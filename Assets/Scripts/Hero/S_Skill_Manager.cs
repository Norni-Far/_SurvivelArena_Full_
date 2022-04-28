using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Skill_Manager : MonoBehaviour
{
    [SerializeField] private S_Shot S_Shot;
    public List<int> skill_lvl = new List<int> (10);
    
    

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
                ExploreSkill_4(number);
                break;
            case 4:
                ExploreSkill_5(number);
                break;
            case 5:
                ExploreSkill_6(number);
                break;
            case 6:
                ExploreSkill_7(number);
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

    private void ExploreSkill_2(int number)
    {
        switch (skill_lvl[number])
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
    private void ExploreSkill_3(int number)
    {
        switch (skill_lvl[number])
        {
            case 1:
                S_Shot.numberOfBullet = 1;
                break;
            case 2:
                transform.GetComponent<S_Shot>().fireDamage += 3;
                break;
            case 3:
                transform.GetComponent<S_Many_Shots>().bulletPrefab = transform.GetComponent<S_Shot>().bulletPrefab[1];
                break;
        }
    }
    private void ExploreSkill_4(int number)
    {
        switch (skill_lvl[number])
        {
            case 1:
                transform.GetComponent<S_Meteor>().enabled = true;
                break;
            case 2:
                transform.GetComponent<S_Meteor>().damageFromMeteor += 40;
                break;
            case 3:
                transform.GetComponent<S_Meteor>().recharge *= 0.6f;
                break;
            case 4:
              //  transform.GetComponent<S_Meteor>().recharge *= 0.6f;
                break;
        }
    }

    private void ExploreSkill_5(int number)
    {
        switch (skill_lvl[number])
        {
            case 1:
                transform.GetComponent<S_HeroMove>().VelocityOfHero *= 1.2f;
                break;
            case 2:
                transform.GetComponent<S_HeroMove>().VelocityOfHero *= 1.2f;
                break;
            case 3:
                transform.GetComponent<S_Herohealth>().dodgeRange += 10;
                break;
            case 4:
                transform.GetComponent<S_Herohealth>().dodgeRange += 20;
                break;
        }
    }

    private void ExploreSkill_6(int number)
    {
        switch (skill_lvl[number])
        {
            case 1:
                transform.GetComponent<S_Herohealth>().Health +=100;
                transform.GetComponent<S_Herohealth>().HealthMax += 100;
                break;
            case 2:
                transform.GetComponent<S_Herohealth>().Health += 200;
                transform.GetComponent<S_Herohealth>().HealthMax += 200;
                break;
            case 3:
                transform.GetComponent<S_Herohealth>().HpRegen += 2;
                break;
            case 4:
                transform.GetComponent<S_Herohealth>().HpRegen += 10;
                break;
            case 5:
               // transform.GetComponent<S_Herohealth>().HpRegen += 10;
                break;
        }
    }

    private void ExploreSkill_7(int number)
    {
        switch (skill_lvl[number])
        {
            case 1:
                transform.GetComponent<S_Shot>().damage += 5;
                break;
            case 2:
                transform.GetComponent<S_Shot>().damage += 10;
                break;
            case 3:
               // transform.GetComponent<S_Herohealth>().dodgeRange += 10;
                break;
            case 4:
            //    transform.GetComponent<S_Herohealth>().dodgeRange += 20;
                break;
        }
    }
}
