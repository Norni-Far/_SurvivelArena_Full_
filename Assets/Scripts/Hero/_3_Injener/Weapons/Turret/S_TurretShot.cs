using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TurretShot : MonoBehaviour
{
    [SerializeField] private CircleCollider2D colliderOfRadiusAttack;
    [SerializeField] private Transform pointOfspawn;
    [SerializeField] private GameObject prefab_LineOfShot;

    [Space]
    [Header("Изменяемые характеристики")]
    public int damageForLine;
    public int radiusOfAttack;
    public int reloadOfAttack;


    private void Start()
    {
        colliderOfRadiusAttack.radius = radiusOfAttack;
    }

    [System.Obsolete]
    public void Shot(GameObject enemy)
    {
        GameObject inst = Instantiate(prefab_LineOfShot, pointOfspawn.position, pointOfspawn.rotation, pointOfspawn.transform);
        inst.GetComponent<S_LineOfTurretBullet>().SetTargetPosition(enemy, damageForLine, radiusOfAttack, reloadOfAttack);
    }
}
