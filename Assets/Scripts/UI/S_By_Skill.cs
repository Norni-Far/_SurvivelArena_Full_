using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_By_Skill : MonoBehaviour
{
    [SerializeField] private int[] skill_lvl = new int[10];
    public void BySkill_1()
    {
        skill_lvl = transform.parent.GetComponent<S_Skill_Add>().skill_lvl;

        switch (skill_lvl[0])
        {
            case 0:

                break;

        }
    }
}
