using UnityEngine;

public class S_SendDamageForHero_NearFight : MonoBehaviour
{
    public int damage;
    public GameObject enemy;

    public void SendDamageForHero()
    {
        if (enemy)
            transform.parent.parent.GetComponent<S_Herohealth>().SetDamage(damage, enemy);
        else
            transform.parent.parent.GetComponent<S_Herohealth>().SetDamage(damage);

    }
}
