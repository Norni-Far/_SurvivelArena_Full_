using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Lut_after_dead : MonoBehaviour
{
    public GameObject ExpObj;

    [SerializeField] private int percentOflut;

    public void Lut()
    {
        int rnd = Random.Range(0, 101);

        if (rnd <= percentOflut)
        {
            GameObject monsterdObj = Instantiate(ExpObj);
            monsterdObj.transform.position = transform.position;
        }

    }

}
