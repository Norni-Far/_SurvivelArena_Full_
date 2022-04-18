using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_bullet_collider : MonoBehaviour
{
    public int damage = 10;
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.TryGetComponent(out Hp_enemy hp_enemy))
        {
            hp_enemy.hit(damage); 
            Destroy(gameObject);
        }
    }
}
