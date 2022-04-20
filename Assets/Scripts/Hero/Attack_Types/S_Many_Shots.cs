using UnityEngine;

public class S_Many_Shots : MonoBehaviour
{
    [SerializeField] private Transform rock;
    public GameObject[] bulletPrefab = new GameObject[5];
    public int damage = 10;
    public int lvl_many_shots;
    public int numberOfBullet;
    public void Shot(Transform Target)//производит выстрел
    {
        if (Target != null)
        {
            switch (lvl_many_shots)
            {
                case 1:
                    plus2(Target, 10);
                    break;
                case 2:
                    plus2(Target, 10);
                    plus2(Target, 20);
                    break;

            }
        }


    }
    private void plus2(Transform Target, int rec)
    {

        if (Target != null)
        {
            GameObject inst = Instantiate(bulletPrefab[numberOfBullet], rock.transform.position, gameObject.transform.rotation);
            inst.GetComponent<S_bullet_collider>().damage = damage;
            Vector3 difference = Target.position - rock.transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            inst.transform.Rotate(inst.transform.rotation.x, inst.transform.rotation.y, rotZ - rec);

        }
        if (Target != null)
        {
            GameObject inst1 = Instantiate(bulletPrefab[numberOfBullet], rock.transform.position, gameObject.transform.rotation);
            Vector3 difference = Target.position - rock.transform.position;
            inst1.GetComponent<S_bullet_collider>().damage = damage;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            inst1.transform.Rotate(inst1.transform.rotation.x, inst1.transform.rotation.y, rotZ + rec);

        }
        
    }

}
