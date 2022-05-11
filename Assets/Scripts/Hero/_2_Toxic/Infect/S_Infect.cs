using UnityEngine;
public class S_Infect : MonoBehaviour
{
    private S_SetDamageForHero herohealth;
    private S_HealthHero healthHero;
    private GameObject enemy;
    public int damage;
    public float timePerSeconds;
    [SerializeField] private GameObject infectPrefab;
    public int treatForHero;

    private void Start()
    {
        herohealth = transform.GetComponent<S_SetDamageForHero>();
        healthHero = transform.GetComponent<S_HealthHero>();
    }
    private void FixedUpdate()
    {
        if (herohealth.enemyObject != null)
        {
            if (herohealth.enemyObject != enemy)
            {
                enemy = herohealth.enemyObject;
                enemy.AddComponent<S_Infect_for_enemy>();
                S_Infect_for_enemy Infect = enemy.GetComponent<S_Infect_for_enemy>();
                Infect.damage = damage;
                Infect.timePerSeconds = timePerSeconds;
                Infect.heroHealth = healthHero;
                Infect.treatForHero = treatForHero;
                GameObject cloud = Instantiate(infectPrefab, enemy.transform);
                cloud.transform.localPosition = new Vector2(0, 0);
            }


        }

    }
}
