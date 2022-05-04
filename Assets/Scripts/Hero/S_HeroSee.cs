﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_HeroSee : MonoBehaviour
{
    [SerializeField] private S_Shot_forHero_1_Atilus s_Shot_forHero_1_Atilus;
    [SerializeField] private S_Shot_forHero_2_HHH s_Shot_forHero_2_HHH;

    [SerializeField] private CircleCollider2D CircleRadiusSee;
    [SerializeField] private List<GameObject> ISeeIts = new List<GameObject>();

    public int numberOfHero;

    public GameObject Target;
    public bool canShot;
    public float timeForReloadOfShot;
    private void Start()
    {
        StartCoroutine(UpdateListOfEnemy());
        StartCoroutine(TimerForFire());
    }

    IEnumerator TimerForFire()
    {
        switch (numberOfHero)
        {
            case 0:
                while (true)
                {
                    //проверна на возможность стрельбы
                    yield return new WaitUntil(() => canShot);

                    //выстрел
                    if (Target != null)
                    {
                        // обычная стрельба 
                        s_Shot_forHero_1_Atilus.Shot(Target.transform);

                        // особая стрельба (работает отдельно) 
                    }

                    // перезарядка
                    yield return new WaitForSeconds(timeForReloadOfShot);
                }

            case 1:
                while (true)
                {
                    //проверна на возможность стрельбы
                    yield return new WaitUntil(() => canShot);

                    //выстрел
                    if (Target != null)
                    {
                        // обычная стрельба 
                        s_Shot_forHero_2_HHH.Shot(Target.transform);

                        // особая стрельба (работает отдельно) 
                    }

                    // перезарядка
                    yield return new WaitForSeconds(timeForReloadOfShot);
                }
        }
    }

    #region Поиск и обновление списка врагов

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

    #endregion
}
