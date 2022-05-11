using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Obsolete]

public class S_LineOfTurretBullet : MonoBehaviour
{
    [SerializeField] private LineRenderer lineOfAttck;
    [SerializeField] private ParticleSystem effectOfTuchFromLazer;

    [SerializeField] private GameObject enemyoOject;
    private S_Hp_enemy s_hpEnemy;

    private float reloadOfAttack;
    private float distanceFire;
    private int damageForline;

    private void Start()
    {
        StartCoroutine(SendDamage());
        lineOfAttck.SetPosition(0, transform.position);
    }


    private void Update()
    {
        if (enemyoOject)
        {
            lineOfAttck.SetPosition(1, enemyoOject.transform.position);
            effectOfTuchFromLazer.gameObject.transform.position = lineOfAttck.GetPosition(1);
        }
        else
        {
            effectOfTuchFromLazer.gameObject.transform.parent = null;
            effectOfTuchFromLazer.loop = false;
            Destroy(gameObject);
        }
    }

    public void SetTargetPosition(GameObject target, int _damageForline, float radiusOfAttack, float _reloadOfattack)
    {
        s_hpEnemy = target.GetComponent<S_Hp_enemy>();

        enemyoOject = target;
        damageForline = _damageForline;
        distanceFire = radiusOfAttack;
        reloadOfAttack = _reloadOfattack;

        effectOfTuchFromLazer.Play();
    }


    IEnumerator SendDamage()
    {
        yield return new WaitUntil(() => enemyoOject);

        while (true)
        {
            yield return new WaitForSeconds(reloadOfAttack);

            if (distanceFire + 0.5f < Vector2.Distance(lineOfAttck.GetPosition(0), lineOfAttck.GetPosition(1)))
            {
                Destroy(gameObject);
                break;
            }

            s_hpEnemy.hit(damageForline);

        }
    }
}
