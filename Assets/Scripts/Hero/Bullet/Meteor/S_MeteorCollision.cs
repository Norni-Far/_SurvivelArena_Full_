using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MeteorCollision : MonoBehaviour
{
    [SerializeField] private GameObject prefabExplose;

    public GameObject targetPlace;
    public int damage;
    public float radiusDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out S_placeOfMeteor S_placeOfMeteor))
        {
            print(2);
            Instantiate(prefabExplose, transform.position, new Quaternion(0, 0, 0, 0), null);
            if (prefabExplose.TryGetComponent(out S_ExploseFromMeteor_collision_withEnemy S_explose))
            {
                S_explose.damage = damage;
                S_explose.radiusDMG = radiusDamage;
            }
            Destroy(S_placeOfMeteor.gameObject);
            Destroy(gameObject);
        }
    }
}
