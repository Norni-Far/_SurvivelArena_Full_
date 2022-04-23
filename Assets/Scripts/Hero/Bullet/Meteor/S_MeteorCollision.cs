using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MeteorCollision : MonoBehaviour
{
    [SerializeField] private GameObject prefabExplose;

    public GameObject targetPlace;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out S_placeOfMeteor S_placeOfMeteor))
        {

            Instantiate(prefabExplose, transform.position, new Quaternion(0, 0, 0, 0), null);

            Destroy(S_placeOfMeteor.gameObject);
            Destroy(gameObject);
        }
    }
}
