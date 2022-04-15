using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Many_Shots : MonoBehaviour
{
    [SerializeField] private Transform rock;
    public GameObject[] bulletPrefab = new GameObject[5];
    public void Shot(int numberOfBullet, Transform Target)//производит выстрел
    {
        GameObject inst = Instantiate(bulletPrefab[numberOfBullet], rock.transform.position, gameObject.transform.rotation);

        

            if (Target != null)
            {
                Vector3 difference = Target.position - rock.transform.position;
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

                Quaternion rotation = Quaternion.AngleAxis(rotZ -60, Vector3.forward);
                inst.transform.rotation = Quaternion.Slerp(rock.transform.rotation, rotation, Time.deltaTime * 1000);
          
        }
        GameObject inst1 = Instantiate(bulletPrefab[numberOfBullet], rock.transform.position, gameObject.transform.rotation);



        if (Target != null)
        {
            Vector3 difference = Target.position - rock.transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(rotZ -120, Vector3.forward);
            inst1.transform.rotation = Quaternion.Slerp(rock.transform.rotation, rotation, Time.deltaTime * 1000);

        }
    }
}
