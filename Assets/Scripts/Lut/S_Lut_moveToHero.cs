using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Lut_moveToHero : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] float speed;
    private GameObject Player;
    bool Go;
    void Update()
    {
        if (Go)
        {
            /*
            Vector3 difference = Player.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, rotZ);

            transform.parent.position += transform.right * speed / 100;*/

            transform.parent.position = Vector2.MoveTowards(transform.parent.position, Player.transform.position, speed/1000);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out S_Herohealth S_Hero))
        {
            print(1);
            Player = S_Hero.gameObject;
            Go = true;
        }
    }
}
