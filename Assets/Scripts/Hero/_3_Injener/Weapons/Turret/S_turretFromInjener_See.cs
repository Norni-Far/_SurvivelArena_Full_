using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_turretFromInjener_See : MonoBehaviour
{
    [SerializeField] private S_TurretShot S_turretShot;

    [SerializeField] private List<GameObject> ISeeIts = new List<GameObject>();

    private void Start()
    {

    }



    #region Поиск и обновление списка врагов
    private void RemoveEnemyFromList(GameObject Enemy) => ISeeIts.Remove(Enemy);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<S_moveEnemy>(out S_moveEnemy s_moveEnemy))
        {
            ISeeIts.Add(collision.gameObject);
            s_moveEnemy.event_DeadEnemy += RemoveEnemyFromList;

            S_turretShot.Shot(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<S_moveEnemy>(out S_moveEnemy s_moveEnemy))
        {
            ISeeIts.Remove(collision.gameObject);
            s_moveEnemy.event_DeadEnemy -= RemoveEnemyFromList;
        }
    }
    #endregion
}
