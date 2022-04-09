using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Lut_after_dead : MonoBehaviour
{
    public GameObject ExpObj;
    public void Lut()
    {
        if (Random.Range(1, 3) == 1)
        {
            GameObject monsterdObj = Instantiate(ExpObj);
            monsterdObj.transform.position = transform.position;
        }
      
    }
   
}
