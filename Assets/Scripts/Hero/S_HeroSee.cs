using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_HeroSee : MonoBehaviour
{
    [SerializeField] private S_Shot S_shot;
    [SerializeField] private S_Meteor s_SpecialShot;

    [SerializeField] private CircleCollider2D CircleRadiusSee;
    [SerializeField] private List<GameObject> ISeeIts = new List<GameObject>();

    [SerializeField] private int chooseBulletPrefaab;
    public GameObject Target;
    public bool canShot;
    public float timeForReloadOfShot;
    private void Start()
    {
        StartCoroutine(UpdateListOfEnemy());
        StartCoroutine(TimerForFire());
    }


    IEnumerator UpdateListOfEnemy()
    {
        while (true)
        {
            float minDistance = float.MaxValue;

            foreach (var item in ISeeIts)
            {
                float checkDistance = Vector2.Distance(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z), item.transform.position);

                if (item.TryGetComponent(out SpriteRenderer Sprite))
                {
                    Sprite.color = Color.white;
                }

                if (checkDistance < minDistance)
                {
                    minDistance = checkDistance;
                    Target = item;
                }
            }

            if (ISeeIts.Count == 0)
                Target = null;

            if (Target != null) // можно стрелять (цель обнаружена)
            {
                if (Target.TryGetComponent(out SpriteRenderer Sprite))
                {
                    Sprite.color = Color.red;
                }
                canShot = true;
            }
            else
                canShot = false;

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator TimerForFire()
    {
        while (true)
        {
            yield return new WaitUntil(() => canShot);
            if (Target != null)

                // обычная стрельба 
                S_shot.Shot(Target.transform);

            // особая стрельба (работает отдельно) 


            yield return new WaitForSeconds(timeForReloadOfShot);
        }


    }

    private void RemoveEnemyFromList(GameObject Enemy) => ISeeIts.Remove(Enemy);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<S_moveEnemy>(out S_moveEnemy s_moveEnemy))
        {
            ISeeIts.Add(collision.gameObject);
            s_moveEnemy.event_DeadEnemy += RemoveEnemyFromList;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<S_moveEnemy>(out S_moveEnemy s_moveEnemy))
        {
            if (collision.TryGetComponent(out SpriteRenderer Sprite))
            {
                Sprite.color = Color.white;
            }

            ISeeIts.Remove(collision.gameObject);
            s_moveEnemy.event_DeadEnemy -= RemoveEnemyFromList;
        }
    }

    public void menu()
    {

    }

    public void restart()
    {

    }
}
