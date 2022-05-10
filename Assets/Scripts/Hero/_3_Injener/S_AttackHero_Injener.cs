using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AttackHero_Injener : MonoBehaviour
{
    [SerializeField] private GameObject prefab_SimplleTuch;

    [Header("’арактеристики которые можно прокачивать")]
    [Range(min: 1.5f, max: 6f)] public float distanceOfAttck;
    public int simpleDamage;
    [Range(min: 1, max: 200)] public int countOfSimpleTuch;

    public void Shot(List<GameObject> enemylist)
    {
        int a = 0;

        for (int i = 0; i < enemylist.Count; i++)
        {
            if (distanceOfAttck >= Vector2.Distance(gameObject.transform.position, enemylist[i].transform.position))
            {
                GameObject inst = Instantiate(prefab_SimplleTuch, enemylist[i].transform);
                inst.GetComponent<S_sendDamageForEnemy>().SendDamage(simpleDamage);

                a++;
            }

            if (a == countOfSimpleTuch)
                return;
        }

        //foreach (var item in enemylist)
        //{
        //    if (distanceOfAttck >= Vector2.Distance(gameObject.transform.position, item.transform.position))
        //    {
        //        GameObject inst = Instantiate(prefab_SimplleTuch, item.transform);
        //        inst.GetComponent<S_sendDamageForEnemy>().SendDamage(simpleDamage);

        //        a++;
        //    }

        //    if (a == countOfSimpleTuch)
        //        return;

        //}

    }
}
