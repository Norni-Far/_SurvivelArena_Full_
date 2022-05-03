using UnityEngine;

public class S_scroll_hero_panel : MonoBehaviour
{

    [SerializeField] GameObject[] panel_hero = new GameObject[10];
    public int activePanelHero = 0;
    private float speed;
    private bool active;
    private bool direction;
    [SerializeField] float speedMax;


    public void left()
    {
        if (!active && activePanelHero != 0)
        {
            activePanelHero--;
            active = true;
            direction = false;
            speed = speedMax;
        }

    }
    public void right()
    {
        if (!active && panel_hero[activePanelHero + 1] != null)
        {
            activePanelHero++;
            active = true;
            direction = true;
            speed = speedMax;
        }
    }
    private void FixedUpdate()
    {
        if (active)
        {
            
            speed += 0.5f; // ускорение
            if (panel_hero[activePanelHero].transform.position.x < Screen.width/2 + 40 && panel_hero[activePanelHero].transform.position.x > Screen.width / 2 - 40 && speed > 3)
            {
                speed = speed / 5f;
            }
            if (direction)
                transform.position = new Vector2(transform.position.x - speed, transform.position.y);
            else
                transform.position = new Vector2(transform.position.x + speed, transform.position.y);

            if (panel_hero[activePanelHero].transform.position.x < Screen.width / 2 + 5 && panel_hero[activePanelHero].transform.position.x > Screen.width / 2 - 5)
                active = false;
        }
       
    }
}
