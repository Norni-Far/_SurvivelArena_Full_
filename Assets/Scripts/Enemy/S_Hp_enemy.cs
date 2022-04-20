using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Hp_enemy : MonoBehaviour
{
    public int hp_enemy = 3;

    public void hit(int damage)
    {
        hp_enemy -= damage;

        if (hp_enemy <= 0)
        {
            transform.GetComponent<S_Lut_after_dead>().Lut();
            Destroy(gameObject);
        }
    }


}
