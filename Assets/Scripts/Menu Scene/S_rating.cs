using UnityEngine;
using UnityEngine.UI;

public class S_rating : MonoBehaviour
{
    [SerializeField] private GameObject tableRating;
    private object[,] point = new object [5,50];
    private int number;
    private string timeStr;

    private void OnEnable()
    {
        number = PlayerPrefs.GetInt("number") + 1; // загружаем номер последней игры
        for (int i = 0; i <= number; i++)
        {
           
            point[0, i] = PlayerPrefs.GetInt("timer" + i);
            point[1, i] = PlayerPrefs.GetInt("point" + i);
            point[2, i] = PlayerPrefs.GetInt("lvl" + i);
        }
        sorting(point); // сортировка рекордов
        deletePoint();//удаление лишних рекордов
        filling(); //вывод рекордов
        


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
            tableRating.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = "Время: " + timeStr;
            tableRating.transform.GetChild(i).GetChild(1).GetComponent<Text>().text = "Очки: " + point[1, i];
            tableRating.transform.GetChild(i).GetChild(2).GetComponent<Text>().text = "Уровень: " + point[2,i];
        }
    }

    private void StrTime(int time)
    {
        
        timeStr = (time % 60).ToString() + "c";
        if (time >= 60)
        {
            time /= 60;
            timeStr = time.ToString() + "м " + timeStr;
        }
        if (time >= 60)
        {
            time /= 60;
            timeStr = time.ToString() + "ч " + timeStr;
        }
      
    }
    private void deletePoint()
    {
        if (number > 5)
        {
            for (int i = 0; i < number; i++)
            {
                PlayerPrefs.SetInt("point" + number, 0);
                PlayerPrefs.SetInt("timer" + number, 0);
                PlayerPrefs.SetInt("number", 0);
                PlayerPrefs.Save();
            }
            for (int i = 0; i < number; i++)
            {
                PlayerPrefs.SetInt("point" + i, (int)point[1, i]);
                PlayerPrefs.SetInt("timer" + i, (int)point[0, i]);
                PlayerPrefs.Save();
            }
            number = 5;
        }
    }
}
