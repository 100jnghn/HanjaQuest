using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapMove : MonoBehaviour
{
    public GameObject[] targetPosition;
    public bool startMoving = false; // �̵� ���� ���θ� �����ϴ� ����

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

    // �̵��� �����ϵ��� �ϴ� �޼���
    public void StartMove()
    {
        startMoving = true;
        a++;
    }

    // �̵��� ���ߵ��� �ϴ� �޼���
    public void StopMove()
    {
        startMoving = false;
    }
}
