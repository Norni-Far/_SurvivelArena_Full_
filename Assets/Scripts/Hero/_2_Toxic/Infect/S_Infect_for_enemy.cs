using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Infect_for_enemy : MonoBehaviour
{
    public int damage = 1;
    public float timePerSeconds = 1;
    public S_Hp_enemy hp_Enemy;

    private void Start()
    {
       
        hp_Enemy = transform.GetComponent<S_Hp_enemy>();
        timePerSeconds = 1;
        StartCoroutine(damageForEnemy());

    }

    IEnumerator damageForEnemy()
    {
        while (true)
        {
            hp_Enemy.hit(damage);
            yield return new WaitForSeconds(timePerSeconds);
        }

    }
}
