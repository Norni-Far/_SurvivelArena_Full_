using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Skill_Add : MonoBehaviour
{
    [SerializeField] GameObject content_skills;
    [SerializeField] S_Buy_Skill s_Buy_Skill;
    [SerializeField] private GameObject[] skill_Obj = new GameObject[10];
    [SerializeField] public int[] skill_lvl = new int[10]; //дл€ того, чтобы знать какой лвл прокачки у скила

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
                    skill2(skill_Obj[number]);
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
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "ƒает один дополнительный снар€д.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "ƒает один дополнительный снар€д. ”рон увеличиваетс€ на 5.";
                break;
            case 3:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "ƒает один дополнительный снар€д. —коросто вылета дополнительных снар€дов увеличена.";
                break;
        }
    }

    private void skill2(GameObject panel)
    {
        switch (skill_lvl[1])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "—трел€ет сразу трем€ снар€дами.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "”величивает урон дополнительных снар€дов на 5";
                break;
            case 3:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "”величивает урон дополнительных снар€дов на 10.";
                break;
            case 4:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "ƒает еще два дополнительных снар€да.";
                break;
        }
    }
    
}
