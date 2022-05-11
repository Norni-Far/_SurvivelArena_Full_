using System.Collections;
using UnityEngine;

public class SecondChance : MonoBehaviour
{
    public float timeSecondChance = 5;

    public void startSecondChance()
    {
        StartCoroutine(damageForEnemy());

    }

    IEnumerator damageForEnemy( )
    {
            yield return new WaitForSeconds(timeSecondChance);
            GetComponent<S_Herohealth>().treatAfterChance();

    }

}
