using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Herohealth : MonoBehaviour
{
    //скрипты 
    private S_HeroSee s_See;
    public delegate void delegats();
    public event delegats event_deadHero;

    [HideInInspector] public int numberOfHero;

    public int dodgeRange;
    public int protection;
    public int HpRegen = 0;
    public int HealthMax = 400;
    public int Health;
    public bool secondChanceActive;
    private bool activeChance; // активна ли способность сейчас
    [SerializeField] private RectTransform hp_jbject;
    private int startHealth;
    public GameObject enemyObject;

    public void BirthHero()  //вместо Start
    {
        switch (numberOfHero)
        {
            case 0:
                s_See = transform.GetComponent<S_HeroSee>();
                s_See.numberOfHero = numberOfHero;
                break;

            case 1:
                break;
        }

        startHealth = Health;
        Health = HealthMax;


        StartCoroutine(HpRegenTimer());
    }

    private void Update()
    {
        UpdateHpHero();
    }

    #region ShowHP
    private void UpdateHpHero()
    {
        startHealth = HealthMax;
        hp_jbject.transform.localPosition = new Vector3(ChangeHpHero(), 0, 0);
    }

    private float ChangeHpHero()
    {
        float nowHp = (float)Health / startHealth * 100;
        float transformHp = -0.75f + (0.75f * nowHp / 100);
        return transformHp;
    }
    #endregion

    #region ѕриЄм урона

    
    public void SetDamage(int Damage, GameObject Enemy) // принимает | урон | кто наносит урон |
    {
        enemyObject = Enemy;
        setDamageContinuation(Damage);
    }
    public void SetDamage(int Damage) // принимает | урон 
    {
        setDamageContinuation(Damage);
    }

    private void setDamageContinuation (int Damage)
    {
        dodgeDamage(Damage);
        damageReduction(Damage);
        Health -= Damage;
        if (Health <= 0)
            secondChance();
           
    }
    #endregion

    private int dodgeDamage(int damage)
    {
        int rnd = Random.Range(0, 100);
        if (rnd < dodgeRange)
            damage = 0;
        return damage;
    }
    private int damageReduction(int damage)
    {
        if (protection >= 0)
            damage -= protection;
        else
            damage /= 2; // особа€ способность, уменьшающа€ урон вдвое
        if (protection == -2)
            returnDamageForEnemy(damage);
        return damage;
    }
     private void returnDamageForEnemy(int damage)
    {
        int returnDamage = damage / 4;
        enemyObject.GetComponent<S_Hp_enemy>().hit(returnDamage);
    }


    IEnumerator HpRegenTimer()
    {
        while (true)
        {
            if (Health < HealthMax)
            {
                Health += HpRegen;

                if (Health > HealthMax) Health = HealthMax;
            }

            yield return new WaitForSeconds(1f);
        }

    }
    public void treat(int hp)
    {
            if (Health < HealthMax)
            {
                Health += hp;

                if (Health > HealthMax) Health = HealthMax;
            }

    }
    private void secondChance()  //скилл второй шанс
    {
        if (!activeChance)
        {
            if (secondChanceActive)
            {
                GetComponent<SecondChance>().startSecondChance();
                activeChance = true;
            }
            else

                DeadIvent();
        }
       
        
    }
    public void treatAfterChance()
    {
        Health = HealthMax / 2;
        secondChanceActive = false;
        activeChance = false;
    }

    public void DeadIvent()
    {
        event_deadHero?.Invoke();
    }


}