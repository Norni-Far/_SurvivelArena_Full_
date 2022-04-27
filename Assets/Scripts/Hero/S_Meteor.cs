using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Meteor : MonoBehaviour
{
    [SerializeField] private GameObject prefabMeteor;
    [SerializeField] private GameObject prefabPlaceOfmeteor;

    [SerializeField] private S_HeroSee S_HeroSee;

    public float reloadForspecialWeapons;

    private GameObject targetEnemy;

    private void Start()
    {
        StartCoroutine(StartReloudSpecialWeapons());
    }

    IEnumerator StartReloudSpecialWeapons()
    {
        while (true)
        {
            yield return new WaitUntil(() => S_HeroSee.canShot);

            targetEnemy = S_HeroSee.Target;

            if (targetEnemy != null)
            {
                GameObject place = Instantiate(prefabPlaceOfmeteor, targetEnemy.transform.position, transform.rotation, null);
                GameObject inst = Instantiate(prefabMeteor, new Vector3(transform.position.x + 10, transform.position.y + 10, transform.position.z), transform.rotation, null);

                inst.GetComponent<S_MeteorMove>().targetPlace = place.transform;

                yield return new WaitForSeconds(reloadForspecialWeapons);
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
