using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Cloud_Toxic : MonoBehaviour
{
    [SerializeField] private GameObject Cloud;
    public float couldown;
    public float timeLife;

    private void Start()
    {
        StartCoroutine(spawnCoud());
    }

    private IEnumerator spawnCoud()
    {
        while(true)
        {
            GameObject cloudPrefab = Instantiate(Cloud);
            cloudPrefab.GetComponent<S_Cloud_damage>().timeLife = timeLife;
            yield return new WaitForSeconds(couldown);
        }
       
    }
}
