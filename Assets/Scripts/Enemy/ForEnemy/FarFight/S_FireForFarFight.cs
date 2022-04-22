using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FireForFarFight : MonoBehaviour
{
    [SerializeField] private GameObject prefabArrow;

    private S_moveEnemy S_MoveEnemy;
    private Transform heroBody;

    public float reloadForArcher;
    public int damageForArrow;
    private void Start()
    {
        StartCoroutine(StartAimForArcher());
    }

    private void Update()
    {
        if (heroBody == null)
        {
            if (transform.TryGetComponent(out S_moveEnemy s_MoveEnemy))
            {
                S_MoveEnemy = s_MoveEnemy;
                if (S_MoveEnemy.hero != null)
                    heroBody = S_MoveEnemy.hero.transform.GetComponentInChildren<CapsuleCollider2D>().gameObject.transform;
            }
        }
    }

    IEnumerator StartAimForArcher()
    {
        yield return new WaitUntil(() => S_MoveEnemy != null);

        while (true)
        {
            yield return new WaitUntil(() => !S_MoveEnemy.isMoving);

            GameObject inst = Instantiate(prefabArrow, transform.position, transform.rotation);
            inst.GetComponent<S_ArcherCollision>().damage = damageForArrow;

            Vector3 difference = heroBody.position - inst.transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            inst.transform.Rotate(inst.transform.rotation.x, inst.transform.rotation.y, rotZ);

            yield return new WaitForSeconds(reloadForArcher);

        }
    }
}
