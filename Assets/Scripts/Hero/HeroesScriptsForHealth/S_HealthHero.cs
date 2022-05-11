using UnityEngine;


public class S_HealthHero : MonoBehaviour //, IHeroHealth
{
    [SerializeField] private int healthHero;
    private int healthHeroMax;
    [SerializeField] private RectTransform hp_object;
    public void Regen(int healthPerSecond)
    {
        if ((healthHero + healthPerSecond) <= healthHeroMax)
            healthHero += healthPerSecond;
        else
            healthHero = healthHeroMax;
        LineHealth();
    }

    public void GetDamageFromEnemy(int Damage)
    {
        healthHero -= Damage;
        LineHealth();
    }
    public void AddHealth(int addHealth)
    {
        healthHeroMax += addHealth;
        healthHero += addHealth;
        LineHealth();
    }
    public void PartTread(int part)
    {
        healthHero = healthHeroMax / part;
        LineHealth();
    }
    private void LineHealth()
    {
        float nowHp = (float)healthHero / healthHeroMax * 100;
        float transformHp = -0.75f + (0.75f * nowHp / 100);
        hp_object.transform.localPosition = new Vector3(transformHp, 0, 0);
    }

    public bool StatusLife()
    {
        if (healthHero <= 0)
            return false;
        else
            return true;
    }
}


