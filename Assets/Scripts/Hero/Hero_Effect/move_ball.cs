using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ball : MonoBehaviour
{
    private float twoPi = Mathf.PI * 2f;
    [SerializeField] private float amplitude = 2.0f;
    [SerializeField] private float frequency = 2.0f;
    void Update()
    {
        float x = amplitude * Mathf.Cos(twoPi * Time.time * frequency);
        float y = amplitude * Mathf.Sin(twoPi * Time.time * frequency);
        transform.localPosition = new Vector3(x, y+1, 0);
    }
}
