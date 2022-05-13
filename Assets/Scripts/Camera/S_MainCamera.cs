using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MainCamera : MonoBehaviour
{
    [SerializeField] private float dumping;
    [SerializeField] private Vector2 offset;
    private Transform Player;
    [SerializeField] private bool freezeX;
    [SerializeField] private int positionFreezeX;

    void LateUpdate()
    {
        if (Player != null)
        {
            Vector3 target;

            target = new Vector3(Player.position.x + offset.x, Player.position.y + offset.y, transform.position.z);

            if (freezeX)
                target = new Vector3(positionFreezeX,target.y,target.z);
            
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }

    public void SetPlayer(Transform Player_T) => Player = Player_T;    

    public void FindPlayer()
    {
        Player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (Player != null)
            transform.position = FindTarget();
    }

    private Vector3 FindTarget()
    {
        return new Vector3(Player.position.x + offset.x, Player.position.y + offset.y, transform.position.z);
    }

}
