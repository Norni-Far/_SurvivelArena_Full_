interface IHeroHealth
{
    void Regen(int healthPerSecond);
    void AddHealth(int addHealth);
    void GetDamageFromEnemy(int damage);
    bool StatusLife();
    void PartTread(int part); // лечит от макс хп  = maxhp / part
}


