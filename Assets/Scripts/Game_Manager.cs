using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private S_Lvl_Slider s_Lvl_Slider;
    [SerializeField] private UI_Manager UI_Manager;
    [SerializeField] private S_MainCamera MainCamera;
    [SerializeField] private S_SpawnEnemy SpawnEnemy;

    [SerializeField] private GameObject[] ChosenCharacter;
    [SerializeField] private GameObject expirianceHeroObj; // объект опыта от героя

    public int NumberHero = 1;

    private void Awake()
    {
        // подписки
        expirianceHeroObj.GetComponent<S_expirianceForHero>().event_SendExpiriance += UI_Manager.GiveExporoenceFromGero;
        ChosenCharacter[NumberHero].GetComponent<S_HeroHealth>().event_deadHero += UI_Manager.TextDead;
        s_Lvl_Slider.event_lvlup += UI_Manager.LvlUpPanelActeve;
        MainCamera.SetPlayer(ChosenCharacter[NumberHero].transform);
        SpawnEnemy.SetPlayer(ChosenCharacter[NumberHero]);
        


    }
}
