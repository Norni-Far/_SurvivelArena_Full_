using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs_Monsters = new GameObject[5];
    [SerializeField] private float timeSpawn;
    [SerializeField] private int maxCountEnemy;
    [Range(min: 5, max: 30)] [SerializeField] private int distanceForTeleportOfEnemy;
    [SerializeField] private List<GameObject> EnemyList = new List<GameObject>();


    //[SerializeField] private Transform cameratr;
    //[SerializeField] private Camera Camera1;

    private GameObject hero;

    //private Vector2 cameraXY;
    //private Vector2 cameraXYup;

    public void SetPlayer(GameObject Player) => hero = Player;


    public void StartSpawnerEnemy(GameObject Player)
    {
        hero = Player;
        StartCoroutine(Startspawn());
    }

    IEnumerator Startspawn()
    {
        while (hero != null)
        {
            yield return new WaitForSeconds(timeSpawn);

            if (EnemyList.Count < maxCountEnemy)
            {
                // ������� ������ � ��������� ��� � ����
                GameObject monsterdObj = Instantiate(enemyPrefabs_Monsters[ChooseEnemyForSpawn()]);
                monsterdObj.GetComponent<S_moveEnemy>().hero = hero;
                EnemyList.Add(monsterdObj);

                // ��������/�������� ��������� �� ��������� ������� 
                monsterdObj.GetComponent<S_moveEnemy>().event_DeadEnemy += RemoveEnemyFromList;

                // ����������� ����� � �������� ������ 
                monsterdObj.GetComponent<S_moveEnemy>().MoveTowwardsHeroCamera();
                monsterdObj.GetComponent<S_moveEnemy>().notLessDistance = distanceForTeleportOfEnemy;  // �������� ���������� ��������� ��� ���������

            }
        }
    }

    private void RemoveEnemyFromList(GameObject Enemy) => EnemyList.Remove(Enemy);

    private int ChooseEnemyForSpawn()
    {
        int rnd = Random.Range(0, 101);


        if (rnd < 10)
            return 2;    // �������
        else if (rnd < 50)
            return 1;  // ������
        else
            return 0;   // �������
    }
}
