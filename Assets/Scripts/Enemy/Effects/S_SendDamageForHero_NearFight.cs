using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SendDamageForHero_NearFight : MonoBehaviour
{
    public int Damage;

    public void SendDamageForHero()
    {
        transform.parent.parent.GetComponent<S_HeroHealth>().SetDamage(Damage, gameObject);
    }
}