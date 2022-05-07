using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Cloud_Toxic : MonoBehaviour
{
    [SerializeField] private GameObject Cloud;
    public float couldown;

    private void Start()
    {

    }

    private IEnumerator spawnCoud()
    {
        while(true)
        {

            yield return new WaitForSeconds(couldown);
        }
       
    }
}
