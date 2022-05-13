using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnEnemyByCollider : MonoBehaviour
{
    [SerializeField] private float timeCooldownSpawn;
    [SerializeField] private int[] damageEnemy;
    [SerializeField] private int[] healthEnemy;
    [SerializeField] private List<GameObject> enemyprefab;
    [SerializeField] private Transform spawn;

    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    IEnumerator spawnEnemy()
    {
        while(true)
            {
            createEnemy();
            yield return new WaitForSeconds(timeCooldownSpawn);
        }
        
    }

    private void createEnemy()
    {
        int number = Random.Range(0, enemyprefab.Count);
        GameObject enemy = Instantiate(enemyprefab[number], spawn);
        enemy.GetComponent<S_Hp_enemy>().hp_enemy = healthEnemy[number];
        enemy.GetComponent<S_AttackEnemyNearFight>().Damage = damageEnemy[number];
    }
}
