using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private S_MainCamera MainCamera;
    [SerializeField] private S_SpawnEnemy SpawnEnemy;

    [SerializeField] private GameObject[] ChosenCharacter;

    private void Awake() //пробуждение
    {
        MainCamera.SetPlayer(ChosenCharacter[1].transform);
        SpawnEnemy.SetPlayer(ChosenCharacter[1]);
    }
}
