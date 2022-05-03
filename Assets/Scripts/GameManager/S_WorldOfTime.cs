using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WorldOfTime : MonoBehaviour
{
    private bool pause;

    public void FrozeTime(int number)
    {
        Time.timeScale = number;
    }
    public void pauseOnPause()
    {
        pause = !pause;
        if (pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;


    }
}
