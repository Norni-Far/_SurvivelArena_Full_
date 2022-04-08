using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_bullet_collider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D enemy)
    {

        if (enemy.gameObject.TryGetComponent(out Hp_enemy hinge))
        {
            enemy.GetComponent<Hp_enemy>().hit(2); //damage (нужен отдельный скрипт)
            Destroy(gameObject);
        }
    }
}
