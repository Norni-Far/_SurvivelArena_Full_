using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_bulletMoveTowardsTarget : MonoBehaviour
{
    private float _speedRotate = 100;
    private float rotZ;
    public Transform target;
    public float speed = 0.1f;


    private void Start() // ������ ����������� ������ ����
    {
        if (target != null)
        {
            Vector3 difference = target.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            Quaternion rotation = Quaternion.AngleAxis(rotZ + -90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * _speedRotate);
        }
    }
    void FixedUpdate()
    {
       
            transform.position += transform.up * speed;


    }
   


}
