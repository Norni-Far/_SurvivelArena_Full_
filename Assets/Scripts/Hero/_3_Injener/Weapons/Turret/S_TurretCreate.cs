using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TurretCreate : MonoBehaviour
{
    [SerializeField] private GameObject prefab_Turret;

    [Header("Характеристики для изменений")]
    public float timeReloadspawn;
    private void Start()
    {
        StartCoroutine(StartCreateTurret());
    }

    IEnumerator StartCreateTurret()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeReloadspawn);
            GameObject inst = Instantiate(prefab_Turret, transform.position, transform.rotation);
        }
    }
}
