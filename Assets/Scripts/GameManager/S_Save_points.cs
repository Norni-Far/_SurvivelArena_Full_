using UnityEngine;

public class S_Save_points : MonoBehaviour
{
    private int number;
    public int point; //заработано очков
    public int numberHero;
    [SerializeField] private S_Lvl_Slider Lvl; //уровень для таблицы рейтинга

    private float timer;


    private void OnDisable()
    {
        number = PlayerPrefs.GetInt(numberHero + "number"); // загружаем номер игры
        number++;

        int timerInt = (int)timer;
        PlayerPrefs.SetInt(numberHero + "timer" + number, timerInt);// время игры
        PlayerPrefs.SetInt(numberHero + "point" + number, point);//колличество очков
        PlayerPrefs.SetInt(numberHero + "lvl" + number, Lvl.lvl);// лвл героя
        PlayerPrefs.SetInt(numberHero + "number", number);  //номер игры
        PlayerPrefs.Save();
    }
    private void FixedUpdate() // нужен другой скрипт
    {
        timer += Time.deltaTime;
    }
   
}
