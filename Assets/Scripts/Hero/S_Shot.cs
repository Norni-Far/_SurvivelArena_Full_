using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Shot : MonoBehaviour
{
    [SerializeField] private Transform rock;
    public GameObject[] bulletPrefab = new GameObject[5];

    
    public void Shot(int numberOfBullet, Transform Target)
    {
        GameObject inst = Instantiate(bulletPrefab[numberOfBullet], gameObject.transform.position, gameObject.transform.rotation);
        inst.transform.position = rock.position;
        inst.GetComponent<S_bulletMoveTowardsTarget>().target = Target;
    }
}
