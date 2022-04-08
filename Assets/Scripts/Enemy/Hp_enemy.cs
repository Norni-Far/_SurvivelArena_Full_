using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_enemy : MonoBehaviour
{
    public int hp_enemy = 3;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void hit(int damage)
    {
        hp_enemy -= damage;
        print(damage);
        if (hp_enemy <= 0)
        {
            Destroy(gameObject);
        }
    }


}
