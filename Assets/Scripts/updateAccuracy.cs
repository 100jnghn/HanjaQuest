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

        accuracy.text = "정확도: " + data.accuracy.ToString("F2") + "%";
        //소수점 둘째자리까지만 나오게 설정했음
    }
}
