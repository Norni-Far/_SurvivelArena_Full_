using System.Collections;
using UnityEngine;

public class S_Cloud_Toxic : MonoBehaviour
{
    [SerializeField] private GameObject Cloud;
    public float couldown;
    public float timeLife;
    public int damage;
    public float scale = 1;

    private void Start()
    {
        StartCoroutine(spawnCoud());
    }

    private IEnumerator spawnCoud()
    {
        while (true)
        {

            spawn();
            yield return new WaitForSeconds(couldown);
        }

    }

    public void spawn()
    {
        GameObject cloudPrefab = Instantiate(Cloud, transform);
        cloudPrefab.GetComponent<S_Cloud_damage>().timeLife = timeLife;
        cloudPrefab.GetComponent<S_Cloud_damage>().damage = damage;
        cloudPrefab.transform.localScale = new Vector2(scale, scale);
    }
}
