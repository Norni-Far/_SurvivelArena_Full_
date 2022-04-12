using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_Shot : MonoBehaviour
{
    public int amount_shots;


    [SerializeField] private Transform rock;
    public GameObject[] bulletPrefab = new GameObject[5];

    
    public void Shot(int numberOfBullet, Transform Target)//производит выстрел
    {
        GameObject inst = Instantiate(bulletPrefab[numberOfBullet], gameObject.transform.position, gameObject.transform.rotation);
        inst.transform.position = rock.position;
        inst.GetComponent<S_bulletMoveTowardsTarget>().target = Target;

        //ниже идут улучшения для выстрелов
        DoubleShot(numberOfBullet, Target);
    }
    

    private void DoubleShot(int numberOfBullet, Transform Target)
    {
        for (int i = 2; i <= amount_shots; i++)
        {
            StartCoroutine(WaitAndPrint(0.3f, numberOfBullet, Target));
        }
        
    }
    private IEnumerator WaitAndPrint(float waitTime, int numberOfBullet, Transform Target) // продолжение doubleShot с паузой
    {
        yield return new WaitForSeconds(waitTime);
        GameObject inst = Instantiate(bulletPrefab[numberOfBullet], gameObject.transform.position, gameObject.transform.rotation);
        inst.transform.position = rock.position;
        inst.GetComponent<S_bulletMoveTowardsTarget>().target = Target;
    }
}
