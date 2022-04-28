using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_skill_panel_active : MonoBehaviour
{
    [SerializeField] private GameObject [] skillActive;
    private int index;

    public void AddSkill(int number)
    {
        if (skillActive[number].transform.GetSiblingIndex() > 9)
        {
            skillActive[number].transform.SetSiblingIndex(index);
            index++;
        }
       
    }
}
