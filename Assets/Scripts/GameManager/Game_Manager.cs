using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    // Скрипты

    [SerializeField] private UI_Manager UI_Manager;
    [SerializeField] private S_MainCamera MainCamera;
    [SerializeField] private S_SpawnEnemy SpawnEnemy;
    [SerializeField] private S_Subscribes S_Subscribes;

    // Герой 
    [SerializeField] private GameObject[] ChosenCharacter;
    [SerializeField] private RectTransform hanglePointForHero;
    private GameObject Character;

    //[SerializeField] private GameObject expirianceHeroObj; // объект опыта от героя

    public int NumberHero;

    public void StartForBtn()
    {
        //создание героя 
        Character = Instantiate(ChosenCharacter[NumberHero], gameObject.transform);
        Character.transform.parent = null;
        S_Subscribes.heroObject = Character;

        HeroIsCreate();

        //Сторонние подписки
        S_Subscribes.StartSubscribes();

        //Старт спавна врагов
        SpawnEnemy.StartSpawnerEnemy(Character);


    }

    private void HeroIsCreate()
    {
        // подключения к герою управления
        Character.GetComponent<S_HeroMove>().HanglePoint = hanglePointForHero;

        // подписки 
        S_Subscribes.Hero_Subscribes();

        MainCamera.SetPlayer(Character.transform);
        SpawnEnemy.SetPlayer(Character);
    }
}
