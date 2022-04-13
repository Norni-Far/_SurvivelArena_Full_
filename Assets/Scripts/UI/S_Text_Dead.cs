using UnityEngine;
using UnityEngine.UI;

public class S_Text_Dead : MonoBehaviour
{

    private void Start()
    {
        transform.GetComponent<Text>().enabled = false;
    }

    public void TextDeadActive() 
    {
        transform.GetComponent<Text>().enabled = true;
    } 

}

