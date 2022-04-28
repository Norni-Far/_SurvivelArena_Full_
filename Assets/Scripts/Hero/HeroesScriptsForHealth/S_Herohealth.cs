using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class S_Herohealth : MonoBehaviour
{
    public delegate void delegats();
    public event delegats event_deadHero;
    public int dodgeRange;
    public int HpRegen = 0;
    public int HealthMax = 400;

    [SerializeField] private RectTransform hp_jbject;

    [SerializeField] public int Health;
    private int startHealth;




    private void Start()
    {
        startHealth = Health;
        StartCoroutine(HpRegenTimer());
    }

    private void Update()
    {
        ShowHpHero();
    }

    #region ShowHP
    private void ShowHpHero()
    {
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
    /// ѕолучение урона героем
    /// </summary>
    /// <param name="Damage">Ќаносимый ”рон</param>
    /// <param name="Enemy"> то наносит урон</param>
    public void SetDamage(int Damage, GameObject Enemy) // принимает | урон | кто наносит урон |
    {
        // шанс увернутьс€ от получени€ урона 
        if (Enemy.TryGetComponent(out S_SendDamageForHero_NearFight S_nearFight)) //ближники 
        {

        }

        if (Enemy.TryGetComponent(out S_ArcherCollision S_arrow)) // дальники 
        {
            //return;
        }
        dodgeDamage(Damage); // скилл уклонени€
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
            }
           
            yield return new WaitForSeconds(1f);
        }
        
    }
}