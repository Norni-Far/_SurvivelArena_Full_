using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Toxin_spawn : MonoBehaviour
{
   
    [SerializeField] private GameObject Toxin;
    public float couldown;
    public float timeLife;
    public int damage;
    [HideInInspector] public S_Herohealth heroHealth; // лечение после смерти
    public int treatForHero;

    private void Start()
    {
        StartCoroutine(spawnCoud());
        heroHealth = GetComponent<S_Herohealth>();
    }

    private IEnumerator spawnCoud()
    {
        while (true)
        {
            GameObject cloudPrefab = Instantiate(Toxin,transform);
            S_Toxin S_Toxin = cloudPrefab.GetComponent<S_Toxin>();
            S_Toxin.couldown = timeLife;
            S_Toxin.toxinDamagePerSeconds = damage;
            S_Toxin.heroHealth = heroHealth;
            S_Toxin.treatForHero = treatForHero;

            yield return new WaitForSeconds(couldown);
        }

    }
}
