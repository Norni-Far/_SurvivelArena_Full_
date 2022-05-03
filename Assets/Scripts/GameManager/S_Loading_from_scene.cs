using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Loading_from_scene : MonoBehaviour
{
    [SerializeField] private Game_Manager GameManager;


    private void OnEnable()
    {
        GameManager.NumberHero = PlayerPrefs.GetInt("hero_namber");
    }
}
