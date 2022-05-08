using UnityEngine;

public class S_Infect : MonoBehaviour
{
    private S_Herohealth herohealth;
    private GameObject enemy;
    public int damage;
    public float timePerSeconds;
    [SerializeField] private GameObject infectPrefab;
    public int treatForHero;

    private void Start()
    {
        herohealth = transform.GetComponent<S_Herohealth>();
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
                Infect.heroHealth = herohealth;
                Infect.treatForHero = treatForHero;
                GameObject cloud = Instantiate(infectPrefab, enemy.transform);
                cloud.transform.localPosition = new Vector2(0, 0);
            }


        }

    }
}
