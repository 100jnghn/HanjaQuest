using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;

public class updateAccuracy : MonoBehaviour
{
    public TextMeshProUGUI accuracy;
    private Data data;
    public CurrentGameData Gdata;


    void Start()
    {
        data = Gdata.Hdata;
    }

    // Update is called once per frame
    void Update()
    {

        accuracy.text = "��Ȯ��: " + data.accuracy.ToString("F2") + "%";
        //�Ҽ��� ��°�ڸ������� ������ ��������
    }
}
