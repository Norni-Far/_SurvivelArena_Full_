using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_time_live : MonoBehaviour
{
    [SerializeField] private float timeDead = 3;

    void Start()
    {
        StartCoroutine(deadBall(timeDead));
       
    }

    private IEnumerator deadBall(float time)
    {
         yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}