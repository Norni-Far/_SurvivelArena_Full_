using UnityEngine;

public class S_ButtonMenu : MonoBehaviour
{
    [SerializeField] private GameObject panelCompani;
    [SerializeField] private GameObject panelArena;
    [SerializeField] private GameObject panelTavern;
    [SerializeField] private GameObject panelLor;
    [SerializeField] private GameObject panelRating;

    public void Compani()
    {
        Enable(panelCompani);
    }

    public void Arena()
    {
        Enable(panelArena);
    }
    public void Tavern()
    {
        Enable(panelTavern);
    }
    public void Lor()
    {
        Enable(panelLor);
    }
    public void Rating()
    {
        Enable(panelRating);
    }
    private void Enable(GameObject panel) => panel.SetActive(!panel.activeInHierarchy);




}
