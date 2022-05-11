using System.Collections;
using UnityEngine;

public class S_Cloud_Toxic : MonoBehaviour
{
    [SerializeField] private GameObject Cloud;
    public float couldown;
    public float timeLife;
    public int damage;
    public float scale = 1;
    [HideInInspector] public S_HealthHero S_HealthHero; // лечение после смерти
    public int treatForHero;

    private void Start()
    {
        StartCoroutine(spawnCoud());
        S_HealthHero = GetComponent<S_HealthHero>();
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
        S_Cloud_damage S_Cloud = cloudPrefab.GetComponent<S_Cloud_damage>();
        S_Cloud.timeLife = timeLife;
        S_Cloud.damage = damage;
        S_Cloud.S_HealthHero = S_HealthHero;
        S_Cloud.treatForHero = treatForHero;
        cloudPrefab.transform.localScale = new Vector2(scale, scale);
    }
}
