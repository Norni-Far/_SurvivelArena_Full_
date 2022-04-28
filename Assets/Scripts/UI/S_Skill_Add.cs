using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Skill_Add : MonoBehaviour
{
    [SerializeField] GameObject content_skills;
    [SerializeField] private List<GameObject> skill_Obj = new List<GameObject> (2);
    [SerializeField] public int[] skill_lvl = new int[10]; //для того, чтобы знать какой лвл прокачки у скила

    private void OnEnable()
    {
        
        RandomSkill();
    }

    private void RandomSkill()
    {
        for (int i = 0; i < 10; i++)
        {
            int number = Random.Range(0, skill_Obj.Count);
            skill_Obj[number].transform.SetAsFirstSibling();

        }
       
        for (int i = 0; i < skill_Obj.Count - 1; i++)
        {
            switch (i)
            {
                case 0:
                    skill1(skill_Obj[i],i);
                    break;
                case 1:
                    skill2(skill_Obj[i],i);
                    break;
                case 2:
                    skill3(skill_Obj[i], i);
                    break;
                case 3:
                    skill4(skill_Obj[i], i);
                    break;
                case 4:
                    skill5(skill_Obj[i], i);
                    break;
                case 5:
                    skill6(skill_Obj[i], i);
                    break;
                case 6:
                    skill7(skill_Obj[i], i);
                    break;
            }
        }
    }

    private void skill1(GameObject panel,int number)
    {
        switch (skill_lvl[number])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Дает один дополнительный снаряд.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Дает один дополнительный снаряд. Урон увеличивается на 5.";
                break;
            case 2:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Дает один дополнительный снаряд. Скоросто вылета дополнительных снарядов увеличена.";
                break;
        }
    }

    private void skill2(GameObject panel, int number)
    {
        switch (skill_lvl[number])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Стреляет сразу тремя снарядами.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает урон дополнительных снарядов на 5.";
                break;
            case 2:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает урон дополнительных снарядов на 10.";
                break;
            case 3:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Дает еще два дополнительных снаряда.";
                break;
        }
    }

    private void skill3(GameObject panel, int number)
    {
        switch (skill_lvl[number])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Добовляет к основному заряду огненный эффект.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает урон от поджога на 3.";
                break;
            case 2:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Добавляет огненный поджег дополнительным снарядам.";
                break;
            case 3:
             //   panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Подожженые враги наносят урон ближайшим врагам.";
                break;
        }
    }

    private void skill4(GameObject panel, int number)
    {
        switch (skill_lvl[number])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Переодически падает метеорит.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Умелививает урон на 40.";
                break;
            case 2:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Метеорит падает чаще.";
                break;
            case 3:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Метеорит оставляет огненный след.";
                break;
            case 4:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Огненный след замедляет передвижение врагов.";
                break;
        }
    }

    private void skill5(GameObject panel, int number)
    {
        switch (skill_lvl[number])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает скорость бега.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает скорость бега.";
                break;
            case 2:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Дает шанс увернуться от атаки.";
                break;
            case 3:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает шанс уворота.";
                break;
        }
    }
    private void skill6(GameObject panel, int number)
    {
        switch (skill_lvl[number])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает здоровье на 100.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает здоровье на 200.";
                break;
            case 2:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Дает регенерацию здоровья.";
                break;
            case 3:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "При смертельной атаке вы получаете второй шанс.";
                break;
        }
    }

    private void skill7(GameObject panel, int number)
    {
        switch (skill_lvl[number])
        {
            case 0:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает урон.";
                break;
            case 1:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Увеличивает урон."; // сколько???
                break;
            case 2:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "Удар по одной и той же цели увеличивает урон.";
                break;
            case 3:
                panel.transform.GetChild(1).transform.GetComponent<Text>().text = "За каждого убитого врага герой получает дополнительный урон";
                break;
        }
    }

}
