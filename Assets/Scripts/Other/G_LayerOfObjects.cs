using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class G_LayerOfObjects : MonoBehaviour
{
    private void Start()
    {
        //gameObject.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(gameObject.transform.position.y) * -1;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.y);
    }

}
