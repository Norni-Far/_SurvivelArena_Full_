using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AttackEnemyNearFight : MonoBehaviour
{
    //для изменений 
    public int Damage;

    [SerializeField] private GameObject PrefabsEffectDamage;
    [SerializeField] private float ReloadAttack;

    private GameObject TuchObject;
    private bool ITuch;
    private void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitUntil(() => ITuch);

            Vector3 Position = new Vector3(TuchObject.transform.position.x, TuchObject.transform.position.y + 0.5f, TuchObject.transform.position.z);
            GameObject Inst = Instantiate(PrefabsEffectDamage, TuchObject.transform);
            Inst.GetComponent<S_SendDamageForHero_NearFight>().Damage = Damage;
            Inst.transform.position = Position;
            Inst.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));

            yield return new WaitForSeconds(ReloadAttack);
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_zoneDamage")
        {
            TuchObject = collision.gameObject;
            ITuch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_zoneDamage")
        {
            ITuch = false;
        }
    }
}
