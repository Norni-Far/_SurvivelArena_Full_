using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SendFireFromFireBall : MonoBehaviour
{
    [SerializeField] private GameObject prefabFire;

    public void SendFireForEnemy(GameObject Enemy)
    {
        Instantiate(prefabFire, Enemy.transform);
    }
}
