using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTest : MonoBehaviour
{
    public GameObject brushCubePrefab;
    public int rows = 50;
    public int columns = 50;
    public float spacing = 0.01f;
   // public GameObject image;
    public Data data;
    public GameObject canvasPosObject;
    public GameObject hanjaCanvas;

    void Start()
    {
        //initData();
        GenerateCanvas();
    }
    public void initData()
    {
        data.totalAnswerCube = 0;
        data.missedCube = 0;
        data.correctCube = 0;
        data.wrongCube = 0;
        data.accuracy = 0.0f;

    }

    public void GenerateCanvas()
    {
        Vector3 canvasPos = canvasPosObject.transform.position;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = canvasPos + new Vector3(j * spacing, i * spacing, 0);
                Instantiate(brushCubePrefab, position, Quaternion.identity, transform);
                //image.gameObject.SetActive(true);
            }
        }
        hanjaCanvas.transform.Rotate(20, 0, 0);
    }

}
