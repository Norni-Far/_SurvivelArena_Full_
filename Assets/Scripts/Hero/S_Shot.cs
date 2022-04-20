using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_Shot : MonoBehaviour
{
    public int amount_shots;
    //private float _speedRotate = 100;

    [SerializeField] private Transform rock;
    public GameObject[] bulletPrefab = new GameObject[5];
    public bool[] skill_active = new bool[20];


    public void Shot(int numberOfBullet, Transform Target)//производит выстрел
    {
        GameObject inst = Instantiate(bulletPrefab[numberOfBullet], rock.transform.position, gameObject.transform.rotation);
        RotationInst(inst,Target);
        

        //ниже идут улучшения для выстрелов
        if (skill_active[0])
        StartCoroutine(WaitAndPrint(0.3f, numberOfBullet, Target));
        if (skill_active[1])
            transform.GetComponent<S_Many_Shots>().Shot(0, Target);
    }
    

    private IEnumerator WaitAndPrint(float waitTime, int numberOfBullet, Transform Target) // продолжение doubleShot с паузой
    {
        for (int i = 2; i <= amount_shots; i++)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject inst = Instantiate(bulletPrefab[numberOfBullet], rock.transform.position, gameObject.transform.rotation);
            RotationInst(inst,Target);
        }
    }
    private void RotationInst(GameObject inst,Transform Target) // задает угол, для полета пули
    {
        if (Target != null)
        {
            Vector3 difference = Target.position - rock.transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(rotZ + -90, Vector3.forward);
            inst.transform.rotation = Quaternion.Slerp(rock.transform.rotation, rotation, Time.deltaTime * 1000);
        }
    }
}
