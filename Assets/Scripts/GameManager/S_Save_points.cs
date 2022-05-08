using UnityEngine;

public class S_Save_points : MonoBehaviour
{
    private int number;
    public int point; //���������� �����
    public int numberHero;
    [SerializeField] private S_Lvl_Slider Lvl; //������� ��� ������� ��������

    private float timer;


    private void OnDisable()
    {
        number = PlayerPrefs.GetInt(numberHero + "number"); // ��������� ����� ����
        number++;

        int timerInt = (int)timer;
        PlayerPrefs.SetInt(numberHero + "timer" + number, timerInt);// ����� ����
        PlayerPrefs.SetInt(numberHero + "point" + number, point);//����������� �����
        PlayerPrefs.SetInt(numberHero + "lvl" + number, Lvl.lvl);// ��� �����
        PlayerPrefs.SetInt(numberHero + "number", number);  //����� ����
        PlayerPrefs.Save();
    }
    private void FixedUpdate() // ����� ������ ������
    {
        timer += Time.deltaTime;
    }
   
}
