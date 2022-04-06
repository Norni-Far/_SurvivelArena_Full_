using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_moveEnemy : MonoBehaviour
{
    public delegate void EnemyDelegats(GameObject Enemy);
    public event EnemyDelegats event_DeadEnemy;

    [HideInInspector] public GameObject hero;
    private Vector2 posHero;

    [SerializeField] private float distans;
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        if (hero != null)
            posHero = hero.transform.position;

        if (Vector2.Distance(posHero, transform.position) > distans)
        {
            transform.position = Vector2.MoveTowards(transform.position, posHero, speed/100);
        }
    }

    private void OnDestroy()
    {
        event_DeadEnemy?.Invoke(gameObject);
    }
}
