using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_time_live_ball : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(deadBall(3));
       
    }

    private IEnumerator deadBall(int time)
    {
         yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}