using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ExploseFromMeteor_collision_withEnemy : MonoBehaviour
{
    public int damage;
    public float radiusDMG;

    private void Start()
    {
        transform.localScale = new Vector3(radiusDMG, radiusDMG, radiusDMG);
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.TryGetComponent(out S_Hp_enemy hp_enemy))
        {
            hp_enemy.hit(damage); //damage (нужен отдельный скрипт)
        }
    }
}
