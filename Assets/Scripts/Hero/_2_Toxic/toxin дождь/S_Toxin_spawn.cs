using System.Collections;
using UnityEngine;

public class S_Toxin_spawn : MonoBehaviour
{
   
    [SerializeField] private GameObject Toxin;
    public float couldown;
    public float timeLife;
    public int damage;
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
            GameObject cloudPrefab = Instantiate(Toxin,transform);
            S_Toxin S_Toxin = cloudPrefab.GetComponent<S_Toxin>();
            S_Toxin.couldown = timeLife;
            S_Toxin.toxinDamagePerSeconds = damage;
            S_Toxin.S_HealthHero = S_HealthHero;
            S_Toxin.treatForHero = treatForHero;

            yield return new WaitForSeconds(couldown);
        }

    }
}
