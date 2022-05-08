using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Infect_for_enemy : MonoBehaviour
{
    public int damage = 1;
    public float timePerSeconds = 1;
    [HideInInspector] public S_Herohealth heroHealth; // лечит героя, после смерти
    public int treatForHero;

    private void Start()
    {

        S_Hp_enemy hp_Enemy = transform.GetComponent<S_Hp_enemy>();
        timePerSeconds = 1;
        StartCoroutine(damageForEnemy(hp_Enemy));

    }

    IEnumerator damageForEnemy(S_Hp_enemy hp_Enemy)
    {
        while (true)
        {
            hp_Enemy.hit(damage);
            yield return new WaitForSeconds(timePerSeconds);
        }

    }

    private void OnDisable()
    {
        if(heroHealth !=null)
        heroHealth.treat(treatForHero);
    }
}
