using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_bullet_collider : MonoBehaviour
{
    // Start is called before the first frame update
    //private void OnCollisonEnter2D(Collision2D enemy)
    //{

    //    if (enemy.gameObject.TryGetComponent(out Hp_enemy hinge))
    //    {
    //        enemy.GetComponent<Hp_enemy>().hit(2); //damage (����� ��������� ������)
    //        Destroy(gameObject);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.TryGetComponent(out Hp_enemy hinge))
        {
            enemy.gameObject.GetComponent<Hp_enemy>().hit(2); //damage (����� ��������� ������)
            Destroy(gameObject);
        }
    }
}
