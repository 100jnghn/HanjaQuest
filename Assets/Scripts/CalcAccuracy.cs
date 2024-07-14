using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcAccuracy : MonoBehaviour
{
    public Data data;
    private float correctCount;
    private float wrongCount;
    private float totalCount;

    void Start()
    {
        correctCount = data.correctCube;
        wrongCount = data.wrongCube;
        totalCount = data.totalAnswerCube;
    }

    void Update()
    {
        Calculate();
    }
    public float Calculate()
    {
        if (data.totalAnswerCube == 0) return 0f;

        data.accuracy = (correctCount - wrongCount) / totalCount * 100f;
        return data.accuracy;
    }
}
