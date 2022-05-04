using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Herohealth : MonoBehaviour
{
    //скрипты 
    [SerializeField] private S_HeroSee s_See;

    public delegate void delegats();
    public event delegats event_deadHero;

    public int numberOfHero;

    public int dodgeRange;
    public int HpRegen = 0;
    public int HealthMax = 400;
    public int Health;

    [SerializeField] private RectTransform hp_jbject;
    private int startHealth;

    public void BirthHero()  //вместо Start
    {
        startHealth = Health;
        Health = HealthMax;
        s_See.numberOfHero = numberOfHero;

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

        if (hp_jbject.transform.localPosition.x > -0.75f)
            hp_jbject.transform.localPosition = new Vector3(ChangeHpHero(), 0, 0);
    }

    private float ChangeHpHero()
    {
        float nowHp = (float)Health / startHealth * 100;
        float transformHp = -0.75f + (0.75f * nowHp / 100);
        return transformHp;
    }
    #endregion

    /// <summary>
    /// Получение урона героем
    /// </summary>
    /// <param name="Damage">Наносимый Урон</param>
    /// <param name="Enemy">Кто наносит урон</param>
    public void SetDamage(int Damage, GameObject Enemy) // принимает | урон | кто наносит урон |
    {
        // шанс увернуться от получения урона 
        if (Enemy.TryGetComponent(out S_SendDamageForHero_NearFight S_nearFight)) //ближники 
        {

        }

        if (Enemy.TryGetComponent(out S_ArcherCollision S_arrow)) // дальники 
        {
            //return;
        }

        dodgeDamage(Damage); // скилл уклонения

        Health -= Damage;
        if (Health <= 0)
            event_deadHero?.Invoke();

    }

    private int dodgeDamage(int damage)
    {
        int rnd = Random.Range(0, 100);
        if (rnd < dodgeRange)
            damage = 0;
        return damage;

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
}