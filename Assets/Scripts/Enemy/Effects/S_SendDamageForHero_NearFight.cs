using UnityEngine;

public class S_SendDamageForHero_NearFight : MonoBehaviour
{
    public int damage;
    public GameObject enemy;

    public void SendDamageForHero()
    {
        transform.parent.parent.GetComponent<S_Herohealth>().SetDamage(damage, enemy);
    }
}
