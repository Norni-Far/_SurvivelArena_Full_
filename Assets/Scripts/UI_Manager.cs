using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private S_Lvl_Slider S_Lvl_Slider;
    [SerializeField] private S_Text_Dead S_Text_Dead;
    [SerializeField] private GameObject LvlUpPanel;

    public void GiveExporoenceFromGero(int exp)
    {
        S_Lvl_Slider.Give_Exp(exp);
    }

    public void TextDead()
    {
        S_Text_Dead.TextDeadActive();
    }

    public void LvlUpPanelActeve()
    {
        LvlUpPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
