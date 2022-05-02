using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_moveEnemy : MonoBehaviour
{
    public delegate void EnemyDelegats(GameObject Enemy);
    public event EnemyDelegats event_DeadEnemy;

    [HideInInspector] public GameObject hero;
    private Vector2 posHero;

    [SerializeField] private float nowDistance;
    public int notLessDistance;

    [SerializeField] private float distans;
    [SerializeField] private float speed;

    private Vector2 cameraXY;
    private Vector2 cameraXYup;

    [Header("Доступная информация об объекте")]
    //доступная информация о объекте 
    public bool isMoving;

    void FixedUpdate()
    {
        if (hero != null)
            posHero = hero.transform.position;

        nowDistance = Vector2.Distance(posHero, transform.position);

        if (nowDistance > distans)
        {
            transform.position = Vector2.MoveTowards(transform.position, posHero, speed / 100);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (nowDistance > notLessDistance)
            MoveTowwardsHeroCamera();
    }

    private void OnDestroy()
    {
        event_DeadEnemy?.Invoke(gameObject);
    }

    public void MoveTowwardsHeroCamera()
    {
        //перемещает объект за границы экрана
        cameraXY.x = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x;
        cameraXY.y = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).y;
        cameraXYup.x = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane)).x;
        cameraXYup.y = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane)).y;

        int i = Random.Range(1, 5);
        switch (i)
        {
            case 1:
                gameObject.transform.localPosition = new Vector2((float)Random.Range(cameraXY.x, cameraXYup.x), cameraXYup.y + 0.2f);
                break;
            case 2:
                gameObject.transform.localPosition = new Vector2((float)Random.Range(cameraXY.x, cameraXYup.x), cameraXY.y - 0.2f);
                break;

            case 3:
                gameObject.transform.localPosition = new Vector2(cameraXYup.x + 0.2f, (float)Random.Range(cameraXY.y, cameraXYup.y));
                break;
            case 4:
                gameObject.transform.localPosition = new Vector2(cameraXY.x - 0.2f, (float)Random.Range(cameraXY.y, cameraXYup.y));
                break;
        }
    }
}
