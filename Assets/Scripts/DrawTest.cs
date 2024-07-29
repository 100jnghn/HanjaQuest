using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
public class DrawTest : MonoBehaviour
{
    public GameObject brushCubePrefab;
    public int rows = 50;
    public int columns = 50;
    public float spacing = 0.01f;
    public GameObject image;
    private Data data;
    public CurrentGameData Gdata;
    public GameObject canvasPosObject;
    public LinkData linkData;
    void Start()
    {
        initData();
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
                image.gameObject.SetActive(true);
            }
        }
    }
    void Update()
    {
        string hanjaName = Gdata.HanjaName;
        //Debug.Log(hanjaName);
        foreach (DictionaryEntry<string, Data> entry in linkData.hanjaDataList)
        {
            Debug.Log(entry.key);

            if (entry.key == hanjaName)
            {
                Debug.Log(hanjaName+"찾았다");
                data = entry.value;
                break;
            }
        }

        if (data != null)
        {
            Gdata.Hdata = data;
        }
        else
        {
            Debug.LogError("Data 파일 못찾음");
        }
    }
}
