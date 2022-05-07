using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AttackHero_Injener : MonoBehaviour
{
    [SerializeField] private GameObject prefab_SimplleTuch;

    [Header("’арактеристики которые можно прокачивать")]
    public float distanceOfAttck;
    public int simpleDamage;
    [Range(min: 1, max: 200)] public int countOfSimpleTuch;

    public void Shot(List<GameObject> enemylist)
    {

        for (int i = 0; i < countOfSimpleTuch; i++)
        {
            if (i < enemylist.Count)
            {
                GameObject inst = Instantiate(prefab_SimplleTuch, enemylist[i].transform);
                inst.GetComponent<S_sendDamageForEnemy>().SendDamage(simpleDamage);
            }
            else
                return;
        }
    }
}
