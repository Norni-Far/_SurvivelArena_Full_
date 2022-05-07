using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ToxinForEnemy : MonoBehaviour
{
    public int damage;
    public float timePerSeconds;
    private S_Hp_enemy hp_Enemy;
    public GameObject toxin;
    private void Start()
    {
        hp_Enemy = transform.GetComponent<S_Hp_enemy>();
        timePerSeconds = 1;
        StartCoroutine(damageForEnemy());
        
    }

    private IEnumerator damageForEnemy()
    {
        while (true)
        {
            if (toxin != null)
                hp_Enemy.hit(damage);
            else
                Destroy(transform.GetComponent<S_ToxinForEnemy>());
            yield return new WaitForSeconds(timePerSeconds);
        }
       
    }
}
