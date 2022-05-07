using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Toxin_spawn : MonoBehaviour
{
   
    [SerializeField] private GameObject Toxin;
    public float couldown;
    public float timeLife;
    public int damage;

    private void Start()
    {
        StartCoroutine(spawnCoud());
    }

    private IEnumerator spawnCoud()
    {
        while (true)
        {
            GameObject cloudPrefab = Instantiate(Toxin,transform);
            cloudPrefab.GetComponent<S_Toxin>().couldown = timeLife;
            cloudPrefab.GetComponent<S_Toxin>().toxinDamagePerSeconds = damage;
            yield return new WaitForSeconds(couldown);
        }

    }
}
