using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeSpawn;
    [SerializeField] private int maxCountEnemy;
    [SerializeField] private List<GameObject> EnemyList = new List<GameObject>();

    //[SerializeField] private Transform cameratr;
    //[SerializeField] private Camera Camera1;

    private GameObject hero;

    private Vector2 cameraXY;
    private Vector2 cameraXYup;

    public void SetPlayer(GameObject Player) => hero = Player;


    void Start()
    {
        StartCoroutine(Startspawn());
    }

    IEnumerator Startspawn()
    {
        while (hero != null)
        {
            yield return new WaitForSeconds(timeSpawn);

            if (EnemyList.Count < maxCountEnemy)
            {
                // создаем обэект и добовляем его в лист
                GameObject monsterdObj = Instantiate(enemyPrefab);
                monsterdObj.GetComponent<S_moveEnemy>().hero = hero;
                EnemyList.Add(monsterdObj);
                // подписка/слежение менеджера за удалением объекта 
                monsterdObj.GetComponent<S_moveEnemy>().event_DeadEnemy += RemoveEnemyFromList;

                //перемещает объект за границы экрана
                cameraXY.x = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).x;
                cameraXY.y = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane)).y;
                cameraXYup.x = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane)).x;
                cameraXYup.y = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane)).y;

                int i = Random.Range(1, 5);
                switch (i)
                {
                    case 1:
                        monsterdObj.transform.localPosition = new Vector2((float)Random.Range(cameraXY.x, cameraXYup.x), cameraXYup.y + 0.2f);
                        break;
                    case 2:
                        monsterdObj.transform.localPosition = new Vector2((float)Random.Range(cameraXY.x, cameraXYup.x), cameraXY.y - 0.2f);
                        break;

                    case 3:
                        monsterdObj.transform.localPosition = new Vector2(cameraXYup.x + 0.2f, (float)Random.Range(cameraXY.y, cameraXYup.y));
                        break;
                    case 4:
                        monsterdObj.transform.localPosition = new Vector2(cameraXY.x - 0.2f, (float)Random.Range(cameraXY.y, cameraXYup.y));
                        break;
                }
            }
        }
    }

    private void RemoveEnemyFromList(GameObject Enemy) => EnemyList.Remove(Enemy);
}
