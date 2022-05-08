using UnityEngine;
using UnityEngine.UI;

public class S_rating : MonoBehaviour
{
    [SerializeField] private GameObject [] tableRating; 
    private object[,] point = new object [5,1000];
    private int number;
    private int numberHero;
    private string timeStr;

    private void OnEnable()
    {
        numberHero = 0;
        Load();
        numberHero++;
        Load();
        numberHero++;
        Load();
        numberHero++;
     //   Load();
        numberHero++;
     //   Load();
    }
    private void Load()
    {
        number = PlayerPrefs.GetInt(numberHero + "number") + 1; // ��������� ����� ��������� ����
        if (number > 999)
            number = 999;
        for (int i = 0; i <= number; i++)
        {
           
            point[0, i] = PlayerPrefs.GetInt(numberHero + "timer" + i);
            point[1, i] = PlayerPrefs.GetInt(numberHero + "point" + i);
            point[2, i] = PlayerPrefs.GetInt(numberHero + "lvl" + i);
        }
        sorting(point); // ���������� ��������
        deletePoint();//�������� ������ ��������
        filling(); //����� ��������
        


    }

    private object[,] sorting(object[,] mass)
    {
        for (int i = 0; i <= number; i++)
        {
            for (int ii = 0; ii < number; ii++)
            {
                if ((int)mass[0, ii] < (int)mass[0, ii + 1])
                {
                    object a = mass[0, ii];
                    mass[0, ii] = mass[0, ii + 1];
                    mass[0, ii + 1] = a;

                    a = mass[1, ii];
                    mass[1, ii] = mass[1, ii + 1];
                    mass[1, ii + 1] = a;

                    a = mass[2, ii];
                    mass[2, ii] = mass[2, ii + 1];
                    mass[2, ii + 1] = a;

                }
                   
            }
        }
        return mass;
    }

    private void filling()
    {
        for (int i = 0; i < number; i++)
        {
            StrTime((int)point[0, i]);
            tableRating[numberHero].transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "�����: " + timeStr;
            tableRating[numberHero].transform.GetChild(i).GetChild(1).GetComponent<Text>().text = "����: " + point[1, i];
            tableRating[numberHero].transform.GetChild(i).GetChild(2).GetComponent<Text>().text = "�������: " + point[2,i];
        }
    }

    private void StrTime(int time)
    {
        
        timeStr = (time % 60).ToString() + "c";
        if (time >= 60)
        {
            time /= 60;
            timeStr = time.ToString() + "� " + timeStr;
        }
        if (time >= 60)
        {
            time /= 60;
            timeStr = time.ToString() + "� " + timeStr;
        }
      
    }
    private void deletePoint()
    {
        if (number > 5)
        {
            for (int i = 0; i < number; i++)
            {
                PlayerPrefs.SetInt(numberHero + "point" + number, 0);
                PlayerPrefs.SetInt(numberHero + "timer" + number, 0);
                PlayerPrefs.SetInt(numberHero + "number", 0);
                PlayerPrefs.Save();
            }
            for (int i = 0; i < number; i++)
            {
                PlayerPrefs.SetInt(numberHero + "point" + i, (int)point[1, i]);
                PlayerPrefs.SetInt(numberHero + "timer" + i, (int)point[0, i]);
                PlayerPrefs.Save();
            }
            number = 5;
        }
    }
}
