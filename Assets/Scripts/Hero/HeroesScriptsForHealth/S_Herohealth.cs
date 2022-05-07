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
    public int HpRegen = 0;
    public int HealthMax = 400;
    public int Health;

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

    #region Приём урона

    /// <summary>
    /// Получение урона героем и приём того кто ударил
    /// </summary>
    /// <param name="Damage">Наносимый Урон</param>
    /// <param name="Enemy">Кто наносит урон</param>
    public void SetDamage(int Damage, GameObject Enemy) // принимает | урон | кто наносит урон |
    {
        enemyObject = Enemy;

        // ecли Токсик, то посылаешь "enemyObject" в другой скрипт: if (transform.TryGetComponent(out S_TocsicHero s_tocsik))

        dodgeDamage(Damage); // скилл уклонения

        Health -= Damage;
        if (Health <= 0)
            event_deadHero?.Invoke();

    }
    /// <summary>
    /// Получение урона героем
    /// </summary>
    /// <param name="Damage">Наносимый урок</param>
    public void SetDamage(int Damage) // принимает | урон 
    {
        dodgeDamage(Damage); // скилл уклонения

        Health -= Damage;
        if (Health <= 0)
            event_deadHero?.Invoke();
    }

    #endregion

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