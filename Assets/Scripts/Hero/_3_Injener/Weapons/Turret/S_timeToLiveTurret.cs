using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_timeToLiveTurret : MonoBehaviour
{

    public float timelive;

    private void Start()
    {
        StartCoroutine(StartLiveTime());
    }

    IEnumerator StartLiveTime()
    {
        yield return new WaitForSeconds(timelive);

        Destroy(gameObject);
    }

}
