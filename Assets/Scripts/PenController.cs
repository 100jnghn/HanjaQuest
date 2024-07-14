using System;
using System.Collections.Generic;
using UnityEngine;
public class PenController : MonoBehaviour
{
    public static Vector3 penPosition;
    private Transform penTransform;
    private bool isTouchingCube = false;
    public GameObject canvas;

    void Start()
    {
        penTransform = GetComponent<Transform>();
    }

    void Update()
    {
        penPosition = penTransform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("canvas"))
        {
            isTouchingCube = true;
            canvas.GetComponent<CanvasController>().SetIsDrawing(true); //canvascontroller��ũ��Ʈ ����
            Debug.Log("collision enter"); //����������� �׷����� �Ϸ���

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("canvas"))
        {
            isTouchingCube = false;
            canvas.GetComponent<CanvasController>().SetIsDrawing(false); 
            Debug.Log("collision exit");
        }
    }
}
