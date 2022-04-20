using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Skill_Add : MonoBehaviour
{
    [SerializeField] GameObject content_skills;
    [SerializeField] S_Buy_Skill s_Buy_Skill;
    [SerializeField] private GameObject[] skill_Obj = new GameObject[10];
    [SerializeField] public int[] skill_lvl = new int[10]; //для того, чтобы знать какой лвл прокачки у скила

    public void OnEnable()
    {
        for (int i = 0; i < content_skills.transform.childCount; i++)
        {
            skill_Obj[i] = content_skills.transform.GetChild(i).gameObject;
        }
        RandomSkill();

    }

    public void RandomSkill()
    {
        for (int i = 0; i < 3; i++)
        {
            int number = Random.Range(0, 3);
            skill_Obj[number].transform.SetAsFirstSibling();
            switch (number)
            {
                case 0:
                    skill1(skill_Obj[number]);
                    break;
                case 1:
                    skill2(skill_Obj[number]);
                    break;
                case 2:
                    skill3(skill_Obj[number]);
                    break;
                case 3:
                    skill2(skill_Obj[number]);
                    break;
            }
        }
    }

    private void skill1(GameObject panel)
    {
        switch (skill_lvl[0])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Дает один дополнительный снаряд.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Дает один дополнительный снаряд. Урон увеличивается на 5.";
                break;
            case 3:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Дает один дополнительный снаряд. Скоросто вылета дополнительных снарядов увеличена.";
                break;
        }
    }

    private void skill2(GameObject panel)
    {
        switch (skill_lvl[1])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Стреляет сразу тремя снарядами.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает урон дополнительных снарядов на 5";
                break;
            case 3:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает урон дополнительных снарядов на 10.";
                break;
            case 4:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Дает еще два дополнительных снаряда.";
                break;
        }
    }
    private void skill3(GameObject panel)
    {
        switch (skill_lvl[1])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Добовляет к основному заряду огненный эффект.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает урон от поджога на 3";
                break;
            case 3:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Добавляет огненный поджег дополнительным снарядам.";
                break;
            case 4:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Подожженые враги наносят урон ближайшим врагам.";
                break;
        }
    }
}
