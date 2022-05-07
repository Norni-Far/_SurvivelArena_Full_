using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_sendDamageForEnemy : MonoBehaviour
{
    public void SendDamage(int damage)
    {
        if (transform.parent.TryGetComponent(out S_Hp_enemy s_Hp_Enemy))
            s_Hp_Enemy.hit(damage);
    }
}
