using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FireForEnemy_SubtractHP : MonoBehaviour
{
    private GameObject Enemy;

    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
        StartCoroutine(StartSubtractHP());
    }

    IEnumerator StartSubtractHP()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (Enemy.TryGetComponent(out S_Hp_enemy s_Hp_Enemy))
            {
                s_Hp_Enemy.hit(1);
            }

        }
    }

}
