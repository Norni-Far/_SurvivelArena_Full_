using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Skill_Add : MonoBehaviour
{
    [SerializeField] private GameObject[] skill_prefab = new GameObject[10];



    public void RandomSkill()
    {
        int number = Random.Range(0,2);
        switch (number)
        {
            case 0:

                break;
        }
    }
}
