using UnityEngine;

public class S_Infect : MonoBehaviour
{
    private S_Herohealth herohealth;
    public GameObject enemy;
    public int damage;
    public float timePerSeconds;

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
                enemy.GetComponent<S_Infect_for_enemy>().damage = damage;
                enemy.GetComponent<S_Infect_for_enemy>().timePerSeconds = timePerSeconds;

            }


        }

    }
}
