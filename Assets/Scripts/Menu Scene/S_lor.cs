using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_lor : MonoBehaviour
{
    [SerializeField] private GameObject LorText;
    [SerializeField] private GameObject heroesImage;
    [SerializeField] private GameObject heroesImage1;
    [SerializeField] private GameObject nameHero;
    [SerializeField] private float spead = 4;
    private bool stage1 = false;
    private float a;//прозрачность героя
    private void FixedUpdate()
    {


        if (!stage1)
            LorText.transform.position = new Vector2(LorText.transform.position.x, LorText.transform.position.y + spead);
        else
        {
            spead += 0.2f;
            LorText.transform.position = new Vector2(LorText.transform.position.x, LorText.transform.position.y - spead);
        }
         


        if (LorText.transform.position.y > 0)
        {
            stage1 = true;
            spead = 100;
        }
            

        if (stage1 && heroesImage.transform.position.y > Screen.height / 2)
        {
            heroesImage.transform.position = new Vector2(heroesImage.transform.position.x, heroesImage.transform.position.y - spead);
        }
        if (stage1 && heroesImage.transform.position.y < Screen.height / 2)
        {
            a += 0.01f;
            heroesImage1.transform.GetComponent<Image>().color = new Color (255, 255, 255, a);
            nameHero.transform.GetComponent<Text>().color = new Color(99, 0, 0, a);
        }
          
    }
}
