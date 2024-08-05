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
    public Data data; //한자데이터
    //public CurrentGameData Gdata; //지금 당장 현 게임 상태

    public static Action zeroAccuracy;  // data의 accuracy를 0으로 만드는 Action

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

        accuracy.text = "정확도: " + data.accuracy.ToString("F2") + "%";
        //소수점 둘째자리까지만 나오게 설정했음
    }

    // data의 accuracy 0으로 초기화
    void resetAccuracy()
    {
        data.accuracy = 0f;
    }
}
