using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Buy_Skill : MonoBehaviour
{
    public delegate void delegats(int number);
    public event delegats event_skillForHero;

    [SerializeField] private int[] skill_lvl = new int[10];
    public void BuySkill_1()
    {
        event_skillForHero?.Invoke(0);
    }
}
