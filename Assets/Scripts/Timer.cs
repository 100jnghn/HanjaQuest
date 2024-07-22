using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float remainTime;
    public bool isStarting;

    void Start()
    {
        
    }

    void Update()
    {
        if(remainTime > 0 && isStarting)
        {
            remainTime -= Time.deltaTime;
        }
    }
}
