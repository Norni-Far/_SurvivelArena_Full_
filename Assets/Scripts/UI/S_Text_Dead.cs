using UnityEngine;
using UnityEngine.UI;

public class S_Text_Dead : MonoBehaviour
{
    [SerializeField] GameObject textDead;
    [SerializeField] GameObject buttonRestart;
    [SerializeField] GameObject buttonMenu;
    private bool dead;
    private float a; //прозрачность панели
    [SerializeField] private S_Scene_Manager Scene_Manager;


    public void TextDeadActive() 
    {
        dead = true;
    }

    private void FixedUpdate()
    {
        if (dead && a < 0.7f)
        {
            a +=0.01f;
            transform.GetComponent<Image>().color = new Color(0, 0, 0, a);
            if (a>=0.7f)
            {
                buttonRestart.SetActive(true);
                buttonMenu.SetActive(true);
                textDead.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void menu()
    {
        Scene_Manager.ChangeScene("menu");
    }

    public void restart()
    {
        Scene_Manager.ChangeScene("arena");
    }
}

