using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class updateAccuracy : MonoBehaviour
{
    public Text accuracy;
    public Data data; //���ڵ�����
    //public CurrentGameData Gdata; //���� ���� �� ���� ����

    public static Action zeroAccuracy;  // data�� accuracy�� 0���� ����� Action

    private void Awake()
    {
        zeroAccuracy = () =>
        {
            resetAccuracy();
        };
    }


    void Start()
    {
        //data = Gdata.Hdata;
    }

    // Update is called once per frame
    void Update()
    {

        accuracy.text = "��Ȯ��: " + data.accuracy.ToString("F2") + "%";
        //�Ҽ��� ��°�ڸ������� ������ ��������
    }

    // data�� accuracy 0���� �ʱ�ȭ
    void resetAccuracy()
    {
        data.accuracy = 0f;
    }
}
