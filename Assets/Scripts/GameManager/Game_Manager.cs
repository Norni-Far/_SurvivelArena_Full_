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
    [SerializeField] private S_ShowHeroHealth_onCanvas S_showHPPlaeyr;
    [SerializeField] private S_Loading_from_scene S_LoadFromScene;

    // Герой 
    [SerializeField] private GameObject[] ChosenCharacter;
    [SerializeField] private RectTransform hanglePointForHero;
    private GameObject Character;

    //[SerializeField] private GameObject expirianceHeroObj; // объект опыта от героя

    public int NumberHero;

    public void StartForBtn()
    {

        // загрузка номмера героя
        //NumberHero = S_LoadFromScene.LoadFromScene();

        Character = Instantiate(ChosenCharacter[NumberHero]);
        S_Subscribes.heroObject = Character;
        Character.GetComponent<S_Herohealth>().numberOfHero = NumberHero;
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
        // передача герою его порядкового номера
        Character.GetComponent<S_Herohealth>().numberOfHero = NumberHero;


        // подписки для героев
        S_Subscribes.Hero_Subscribes(NumberHero);

        MainCamera.SetPlayer(Character.transform);
        SpawnEnemy.SetPlayer(Character);
        S_showHPPlaeyr.SetPlayer(Character);  // перенос персонажа для показа его хп через канвас


        // Старт рождения героя (вместо метода Start у героя)
        Character.GetComponent<S_Herohealth>().BirthHero();
    }
}
