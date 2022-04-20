using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_bullet_collider : MonoBehaviour
{
    [HideInInspector] public int damage;

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.TryGetComponent(out S_Hp_enemy hp_enemy))
        {
            hp_enemy.hit(damage); //damage (нужен отдельный скрипт)

            SupplementedBafs(enemy.gameObject);   //дополнительные бафы на врага

            Destroy(gameObject);
        }
    }

    private void SupplementedBafs(GameObject Enemy)  // дополнительные бафы 
    {
        int rnd = Random.Range(0, 101);

        if (rnd > 30)   // 30% шанс 
        {
            if (gameObject.TryGetComponent(out S_SendFireFromFireBall S_SendFireFromFireBall)) // если мы находимся на FireBall
                S_SendFireFromFireBall.SendFireForEnemy(Enemy); // вешаем огонь на врага 
        }
    }


}
