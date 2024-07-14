using System;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool isDrawing = false;
    private Vector3 lastDrawPosition; // 마지막으로 그린 지점을 저장

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (isDrawing) 
        {
            Vector3 penPosition = PenController.penPosition;
            if (penPosition != lastDrawPosition) // 마지막으로 그린 지점과 다른 경우에만 선을 그림
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, penPosition);
                lastDrawPosition = penPosition; // 마지막으로 그린 지점을 업데이트
            }
        }
    }

    public void SetIsDrawing(bool value)//setDrawing함수는 penController스크립트에서 호출
    {
        isDrawing = value;
        if (value) // 그리기 시작할 때 마지막으로 그린 지점을 초기화
        {
            lastDrawPosition = PenController.penPosition;
        }
    }
    //응 근데 안되쥬
}
