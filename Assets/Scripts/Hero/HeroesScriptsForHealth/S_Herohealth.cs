using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Herohealth : MonoBehaviour
{

    [SerializeField] private int Health;

    public void SetDamage(int Damage)
    {
        Health -= Damage;
    }

}
