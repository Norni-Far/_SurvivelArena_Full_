using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Cloud_damage : MonoBehaviour
{
    public int CloudDamagePerSeconds = 1;
    public float timeLife;
    public int damage;


    private void Start()
    {
        Destroy(gameObject, timeLife);
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.transform.TryGetComponent(out S_Hp_enemy hp_enemy))
        {
            enemy.gameObject.AddComponent<S_ToxinForEnemy>();
            enemy.GetComponent<S_ToxinForEnemy>().toxin = gameObject;
            enemy.GetComponent<S_ToxinForEnemy>().damage = damage;
        }


    }

    private void OnTriggerExit2D(Collider2D enemy)
    {
        if (enemy.transform.TryGetComponent(out S_Hp_enemy hp_enemy) && !enemy.transform.TryGetComponent(out S_ToxinForEnemy toxinForEnemy))
        {

            Destroy(enemy.gameObject.GetComponent<S_ToxinForEnemy>());
        }
    }
}
