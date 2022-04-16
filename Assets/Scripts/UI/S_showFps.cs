using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_showFps : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textFPS;
    [Range(min: 0.01f, max: 1)] [SerializeField] private float timeforShowFps;

    float fps;
    float minFps = 1000;
    float forShowMinFps;
    private void Start()
    {
        StartCoroutine(ShowFps());
        StartCoroutine(ShowFpsMin());
    }

    private void Update()
    {
        fps = 1.0f / Time.deltaTime;
        if (fps < minFps)
            minFps = fps;
    }

    IEnumerator ShowFps()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeforShowFps);
            textFPS.text = fps.ToString() + "/ " + forShowMinFps;
        }
    }

    IEnumerator ShowFpsMin()
    {
        while (true)
        {
            minFps = 1000;
            yield return new WaitForSeconds(3);
            forShowMinFps = minFps;
        }
    }


}
