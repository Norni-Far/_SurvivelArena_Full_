using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MeteorMove : MonoBehaviour
{
    [SerializeField] private S_MeteorCollision S_MeteorCollision; 
    //public Transform enemyTarget;
    public Transform targetPlace;

    [SerializeField] private float speed;
    private void Start()
    {        
        S_MeteorCollision.targetPlace = targetPlace.gameObject;
    }

    private void Update()
    {
        if (targetPlace != null)
        {
            Vector3 difference = targetPlace.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rotZ);

            transform.position += transform.right * speed/100;
        }
    }
}
