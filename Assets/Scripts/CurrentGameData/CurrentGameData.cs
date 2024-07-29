using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Data", menuName = "Game Data", order = 1)]
public class CurrentGameData : ScriptableObject
{
    public string HanjaName;
    public bool hasPassed;
    public Data Hdata;

    void Start()
    {
        HanjaName = "";
        hasPassed = false;
    }

}
