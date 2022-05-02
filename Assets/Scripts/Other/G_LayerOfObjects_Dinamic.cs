using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_LayerOfObjects_Dinamic : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.y / 100);
    }
}
