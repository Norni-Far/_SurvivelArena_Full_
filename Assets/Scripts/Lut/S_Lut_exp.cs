using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Lut_exp : MonoBehaviour
{
    public GameObject sliderExp;

    private void Start()
    {
        sliderExp = transform.gameObject;
    }
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.TryGetComponent(out Hp_enemy hinge))
        {
            gameObject.GetComponent<S_Lvl_Slider>().Give_Exp(2); // заменить двойку на переменную
            Destroy(gameObject);
        }
    }
}
