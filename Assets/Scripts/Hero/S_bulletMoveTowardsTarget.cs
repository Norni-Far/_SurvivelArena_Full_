using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_bulletMoveTowardsTarget : MonoBehaviour
{
    public float speed = 0.1f;

    private void Start()
    {
        transform.GetComponent<Rigidbody2D>().freezeRotation = true;
    }
    void FixedUpdate()
    {
        transform.position += transform.right * speed;
    }
}
