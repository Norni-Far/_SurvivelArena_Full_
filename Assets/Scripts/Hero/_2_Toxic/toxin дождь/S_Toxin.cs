using UnityEngine;

public class S_Toxin : MonoBehaviour
{
    public int toxinDamagePerSeconds = 1;
    public float couldown;
    [HideInInspector] public GameObject hero;
    [HideInInspector] public S_HealthHero S_HealthHero; // лечение после смерти
    public int treatForHero;

    private void Start()
    {
        Destroy(gameObject, couldown);
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if(enemy.transform.TryGetComponent(out S_Hp_enemy hp_enemy))
        {
            enemy.gameObject.AddComponent<S_ToxinForEnemy>();
            S_ToxinForEnemy toxin = enemy.GetComponent<S_ToxinForEnemy>();
            toxin.damage = toxinDamagePerSeconds;
            toxin.toxin = gameObject;
            toxin.heroHealth = S_HealthHero;
            toxin.treatForHero = treatForHero;
        }
    }
    
}
