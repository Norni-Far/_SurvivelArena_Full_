using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Point_for_table : MonoBehaviour // ���������� ���� ui ��� ������� ��������
{
    public S_Save_points Save_Points;
    [SerializeField] private int point;

    public void DeadPoints()
    {
        Save_Points.point += point;
        
    }

}
