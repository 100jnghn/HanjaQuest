using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapMove : MonoBehaviour
{
    public GameObject[] targetPosition;
    public bool startMoving = false; // 이동 시작 여부를 제어하는 변수

    public int a = -1;

    void Start()
    {

    }

    void Update()
    {
        if (startMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition[a].transform.position, Time.deltaTime);
        }
    }

    // 이동을 시작하도록 하는 메서드
    public void StartMove()
    {
        startMoving = true;
        a++;
    }

    // 이동을 멈추도록 하는 메서드
    public void StopMove()
    {
        startMoving = false;
    }
}
