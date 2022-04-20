using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_bullet_collider : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.TryGetComponent(out Hp_enemy hp_enemy))
        {
            hp_enemy.hit(damage); //damage (нужен отдельный скрипт)
=======
    public int damage = 10;
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.TryGetComponent(out Hp_enemy hp_enemy))
        {
            hp_enemy.hit(damage); 
>>>>>>> 032d68bfd81157fdb4b809e29ad5735238621516
            Destroy(gameObject);
        }
    }
}
