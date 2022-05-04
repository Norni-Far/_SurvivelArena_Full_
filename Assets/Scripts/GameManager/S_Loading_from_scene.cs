using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Loading_from_scene : MonoBehaviour
{
    public int LoadFromScene()
    {
        return PlayerPrefs.GetInt("hero_namber");
    }
}
