using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Toxin : MonoBehaviour
{
    public int toxinDamagePerSeconds = 1;
    public float couldown;

    private void Start()
    {
        Destroy(gameObject, couldown);
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.transform.TryGetComponent(out S_Hp_enemy hp_enemy))
        {
                enemy.gameObject.AddComponent<S_ToxinForEnemy>();
            enemy.GetComponent<S_ToxinForEnemy>().damage = toxinDamagePerSeconds;
            enemy.GetComponent<S_ToxinForEnemy>().toxin = gameObject;
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
