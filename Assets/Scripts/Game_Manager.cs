using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private UI_Manager UI_Manager;
    [SerializeField] private S_MainCamera MainCamera;
    [SerializeField] private S_SpawnEnemy SpawnEnemy;

    [SerializeField] private GameObject[] ChosenCharacter;
    [SerializeField] private GameObject expirianceHeroObj; // объект опыта от героя

    private void Awake()
    {
        // подписки
        expirianceHeroObj.GetComponent<S_expirianceForHero>().event_SendExpiriance += UI_Manager.GiveExporoenceFromGero;
        //

        MainCamera.SetPlayer(ChosenCharacter[1].transform);
        SpawnEnemy.SetPlayer(ChosenCharacter[1]);
        
    }
}
