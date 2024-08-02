using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hanja Data", menuName = "Hanja Data", order = 1)]
public class Data : ScriptableObject
{

    
    public int totalAnswerCube;
    public int correctCube;  
    public int wrongCube;
    public int missedCube;
    public float accuracy;
    

    void Start()
    {
        totalAnswerCube = 0;
        missedCube = 0;
        correctCube=0;
        wrongCube=0;
        accuracy = 0.0f;
    }
}
