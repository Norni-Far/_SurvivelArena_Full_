using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SendFireFromFireBall : MonoBehaviour
{
    [SerializeField] private GameObject prefabFire;
    public int fireDamage;

    public void SendFireForEnemy(GameObject Enemy)
    {
         GameObject fire = Instantiate(prefabFire, Enemy.transform);
        fire.GetComponent<S_FireForEnemy_SubtractHP>().fireDamage = fireDamage;
    }
}
