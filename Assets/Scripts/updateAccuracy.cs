using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

public class updateAccuracy : MonoBehaviour
{
    public TextMeshProUGUI accuracy;
    public Data data;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        accuracy.text = "��Ȯ��: " + data.accuracy.ToString("F2") + "%";
        //�Ҽ��� ��°�ڸ������� ������ ��������
    }
}
