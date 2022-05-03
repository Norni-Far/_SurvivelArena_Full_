using UnityEngine;

public class S_Save_points : MonoBehaviour
{
    private int number;
    public int point; //���������� �����
    [SerializeField] private S_Lvl_Slider Lvl; //������� ��� ������� ��������

    private float timer;

    private void OnEnable()
    {
        number = PlayerPrefs.GetInt("number"); // ��������� ����� ����
        number++;
    }
    private void OnDisable()
    {
        int timerInt = (int)timer;
        PlayerPrefs.SetInt("timer" + number, timerInt);
        PlayerPrefs.SetInt("point" + number, point);
        PlayerPrefs.SetInt("lvl" + number, Lvl.lvl);
        PlayerPrefs.SetInt("number", number);
        PlayerPrefs.Save();
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
    }


}
