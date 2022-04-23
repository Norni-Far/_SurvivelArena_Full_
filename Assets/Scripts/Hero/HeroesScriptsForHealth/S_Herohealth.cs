using UnityEngine;

public class S_HeroHealth : MonoBehaviour
{
    public delegate void delegats();
    public event delegats event_deadHero;

    [SerializeField] private RectTransform hp_jbject;

    [SerializeField] private int Health;
    private int startHealth;

    private void Start()
    {
        startHealth = Health;
    }

    private void Update()
    {
        ShowHpHero();
    }

    #region ShowHP
    private void ShowHpHero()
    {
        if (hp_jbject.transform.localPosition.x > -0.75f)
            hp_jbject.transform.localPosition = new Vector3(ChangeHpHero(), 0, 0);
    }

    private float ChangeHpHero()
    {
        float nowHp = (float)Health / startHealth * 100;
        float transformHp = -0.75f + (0.75f * nowHp / 100);
        return transformHp;
    }
    #endregion

    /// <summary>
    /// Получение урона героем
    /// </summary>
    /// <param name="Damage">Наносимый Урон</param>
    /// <param name="Enemy">Кто наносит урон</param>
    public void SetDamage(int Damage, GameObject Enemy) // принимает | урон | кто наносит урон |
    {
        // шанс увернуться от получения урона 
        if (Enemy.TryGetComponent(out S_SendDamageForHero_NearFight S_nearFight)) //ближники 
        {

        }

        if(Enemy.TryGetComponent(out S_ArcherCollision S_arrow)) // дальники 
        {
            //return;
        }

        Health -= Damage;
        if (Health <= 0)
            event_deadHero?.Invoke();

    }
}
