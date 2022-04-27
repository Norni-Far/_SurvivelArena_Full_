 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_rating : MonoBehaviour
{
    [SerializeField] private Text [ ] point= new Text [10]; 

    private void OnEnable()
    {
        int number = 0;
        while (point[number])
        {
            point[number].text = PlayerPrefs.GetInt("Point"+number).ToString();
        }
    }
}
