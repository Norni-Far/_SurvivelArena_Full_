using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Skill_Add : MonoBehaviour
{
    [SerializeField] GameObject content_skills;
    [SerializeField] private GameObject[] skill_Obj = new GameObject[10];
    [SerializeField] public int[] skill_lvl = new int[10]; //��� ����, ����� ����� ����� ��� �������� � �����

    private void OnEnable()
    {
        
        RandomSkill();

    }

    private void RandomSkill()
    {
        for (int i = 0; i < 10; i++)
        {
            int number = Random.Range(0, 3);
            skill_Obj[number].transform.SetAsFirstSibling();

        }
       
        for (int i = 0; i < content_skills.transform.childCount - 1; i++)
        {
            switch (i)
            {
                case 0:
                    skill1(skill_Obj[i]);
                    break;
                case 1:
                    skill2(skill_Obj[i]);
                    break;
                case 2:
                    skill3(skill_Obj[i]);
                    break;
                case 3:
                    skill2(skill_Obj[i]);
                    break;
            }
        }
    }

    private void skill1(GameObject panel)
    {
        switch (skill_lvl[0])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "���� ���� �������������� ������.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "���� ���� �������������� ������. ���� ������������� �� 5.";
                break;
            case 2:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "���� ���� �������������� ������. �������� ������ �������������� �������� ���������.";
                break;
        }
    }

    private void skill2(GameObject panel)
    {
        switch (skill_lvl[1])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "�������� ����� ����� ���������.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "����������� ���� �������������� �������� �� 5";
                break;
            case 2:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "����������� ���� �������������� �������� �� 10.";
                break;
            case 3:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "���� ��� ��� �������������� �������.";
                break;
        }
    }

    private void skill3(GameObject panel)
    {
        switch (skill_lvl[2])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "��������� � ��������� ������ �������� ������.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "����������� ���� �� ������� �� 3";
                break;
            case 2:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "��������� �������� ������ �������������� ��������.";
                break;
            case 3:
             //   panel.transform.GetChild(1).transform.GetComponent<Text>().text = "���������� ����� ������� ���� ��������� ������.";
                break;
        }
    }

}
