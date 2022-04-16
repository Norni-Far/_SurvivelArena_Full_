using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Skill_Add : MonoBehaviour
{
    [SerializeField] private GameObject[] plase_for_skills = new GameObject[3];
    [SerializeField] private GameObject[] skill_prefab = new GameObject[10];
    [SerializeField] public int[] skill_lvl = new int[10]; //дл€ того, чтобы знать какой лвл прокачки у скила

    public void OnEnable()
    {
        RandomSkill();
    }

    public void RandomSkill()
    {
        for (int i = 0; i < 3; i++)
        {
            int number = Random.Range(0, 2);
            GameObject panel1 = Instantiate(skill_prefab[number], plase_for_skills[i].transform.position, transform.rotation);
            panel1.transform.SetParent(plase_for_skills[i].transform);
            switch (number)
            {
                case 0:
                    
                    skill1(panel1);
                    break;
                case 1:
                    skill2(panel1);
                    break;
                case 2:
                    skill1(panel1);
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
    private void OnDisable()
    {
        for (int i = 0; i < 3; i++)
            Destroy(plase_for_skills[i].transform.GetChild(0).gameObject);
    }
}
