using System;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool isDrawing = false;
    private Vector3 lastDrawPosition; // ���������� �׸� ������ ����

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (isDrawing) 
        {
            Vector3 penPosition = PenController.penPosition;
            if (penPosition != lastDrawPosition) // ���������� �׸� ������ �ٸ� ��쿡�� ���� �׸�
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, penPosition);
                lastDrawPosition = penPosition; // ���������� �׸� ������ ������Ʈ
            }
        }
    }

    public void SetIsDrawing(bool value)//setDrawing�Լ��� penController��ũ��Ʈ���� ȣ��
    {
        isDrawing = value;
        if (value) // �׸��� ������ �� ���������� �׸� ������ �ʱ�ȭ
        {
            lastDrawPosition = PenController.penPosition;
        }
    }
    //�� �ٵ� �ȵ���
}
