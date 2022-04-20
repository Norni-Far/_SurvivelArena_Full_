using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_bullet_collider : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.TryGetComponent(out Hp_enemy hp_enemy))
        {
            hp_enemy.hit(damage); //damage (нужен отдельный скрипт)
            Destroy(gameObject);
        }
    }
}
