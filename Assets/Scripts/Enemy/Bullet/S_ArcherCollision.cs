using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class S_ArcherCollision : MonoBehaviour
{
    [SerializeField] private S_bulletMoveTowardsTarget S_moveArrow;

    [HideInInspector] public int damage;
    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.TryGetComponent(out S_heroBody S_heroBody))
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.transform.parent = S_heroBody.gameObject.transform;

            // отнимание жизней
            S_heroBody.transform.parent.parent.GetComponent<S_Herohealth>().SetDamage(damage, gameObject);
            S_moveArrow.enabled = false;

            Destroy(this);
        }
    }
}
