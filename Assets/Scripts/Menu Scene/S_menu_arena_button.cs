using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_menu_arena_button : MonoBehaviour
{
    [SerializeField] private S_Scene_Manager Scene_Manager;

    public void StartArena()
    {
        int numberHero = transform.GetComponent<S_scroll_hero_panel>().activePanelHero;
        PlayerPrefs.SetInt("hero_namber", numberHero);
        PlayerPrefs.Save();
        Scene_Manager.ChangeScene("arena");

    }
}
