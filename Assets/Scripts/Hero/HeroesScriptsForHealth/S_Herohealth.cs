using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class S_Herohealth : MonoBehaviour
{
    [SerializeField] private RectTransform hp_jbject;

    [SerializeField] private int Health;
    private int startHealth;

    private void Start()
    {
        startHealth = Health;
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


    public void SetDamage(int Damage)
    {
        Health -= Damage;
    }
}
