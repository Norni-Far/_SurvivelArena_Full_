using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Cloud_damage : MonoBehaviour
{
    public int CloudDamagePerSeconds = 1;
    public float timeLife;
    public int damage;
    [HideInInspector] public S_Herohealth heroHealth; // лечение после смерти
    public int treatForHero;

    private void Start()
    {
        Destroy(gameObject, timeLife);
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.transform.TryGetComponent(out S_Hp_enemy hp_enemy))
        {
            enemy.gameObject.AddComponent<S_ToxinForEnemy>();
            S_ToxinForEnemy toxin = enemy.GetComponent<S_ToxinForEnemy>();
            toxin.toxin = gameObject;
            toxin.damage = damage;
            toxin.heroHealth = heroHealth;
            toxin.treatForHero = treatForHero;

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
