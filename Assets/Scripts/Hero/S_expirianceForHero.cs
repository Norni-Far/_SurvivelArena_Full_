using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_expirianceForHero : MonoBehaviour
{
    public delegate void Delegats(int exp);
    public event Delegats event_SendExpiriance;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<S_Lut_exp>(out S_Lut_exp S_lut))
        {
            event_SendExpiriance?.Invoke(S_lut.exp);
        }
    }

}
