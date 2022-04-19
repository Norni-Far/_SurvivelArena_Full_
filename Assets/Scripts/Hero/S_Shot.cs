using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_Shot : MonoBehaviour
{
    public int amount_shots;

    [SerializeField] private Transform rock;
    public GameObject[] bulletPrefab = new GameObject[5];
    public bool[] skill_active = new bool[20];
    public int damage = 10;
    public float pauseShot = 0.3f;


    public void Shot(int numberOfBullet, Transform Target)//производит выстрел
    {
        StartCoroutine(WaitAndPrint(pauseShot, numberOfBullet, Target));
    }
    

    private IEnumerator WaitAndPrint(float waitTime, int numberOfBullet, Transform Target) // продолжение doubleShot с паузой
    {
        for (int i = 1; i <= amount_shots; i++)
        {
            if (Target != null)
            {
                yield return new WaitForSeconds(waitTime);
                GameObject inst = Instantiate(bulletPrefab[numberOfBullet], rock.transform.position, gameObject.transform.rotation);
                inst.GetComponent<S_bullet_collider>().damage = damage;
                RotationInst(inst, Target);
                if (skill_active[1])
                    transform.GetComponent<S_Many_Shots>().Shot(0, Target);
            }
           
        }
    }
    private void RotationInst(GameObject inst,Transform Target) // задает угол, для полета пули
    {
        if (Target != null)
        {
            Vector3 difference = Target.position - rock.transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            inst.transform.Rotate(inst.transform.rotation.x, inst.transform.rotation.y,rotZ);
        }
    }
}
