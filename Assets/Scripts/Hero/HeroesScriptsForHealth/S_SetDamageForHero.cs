using System.Collections;
using UnityEngine;


public class S_SetDamageForHero : MonoBehaviour
{
    private S_HealthHero health;
    public delegate void delegats();
    public event delegats event_deadHero;

    public int dodgeRange;
    public int protection;
    public bool secondChanceActive;
    private bool activeChance; // активна ли способность сейчас
    public GameObject enemyObject;
    public int treatPerSecond;



    public void BirthHero()  //вместо Start
    {
        health = GetComponent<S_HealthHero>();
        health.AddHealth(200);
        StartCoroutine(HpRegenTimer());
    }


    public void SetDamage(int Damage, GameObject Enemy) // принимает | урон | кто наносит урон |
    {
        enemyObject = Enemy;
        setDamageContinuation(Damage);
    }
    public void SetDamage(int Damage) // принимает | урон 
    {
        setDamageContinuation(Damage);
    }

    private void setDamageContinuation(int Damage)
    {
        Damage = dodgeDamage(Damage);
        Damage = damageReduction(Damage);
        health.GetDamageFromEnemy(Damage);
        if (!health.StatusLife())
            secondChance();

    }
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
            damage /= 2; // особая способность, уменьшающая урон вдвое
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
            health.Regen(treatPerSecond);
            yield return new WaitForSeconds(1f);
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
        health.PartTread(2);
        secondChanceActive = false;
        activeChance = false;
    }

    public void DeadIvent()
    {
        event_deadHero?.Invoke();
    }


}


