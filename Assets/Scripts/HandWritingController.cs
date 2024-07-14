using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandwritingController : MonoBehaviour
{
    public Material handwritingMaterial; 
    public float brushSize = 10.0f;
    public float pressure = 1.0f; 
    public GameObject penObject;
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material = handwritingMaterial;
        Debug.Log("Pen object found: " + (penObject != null ? "yes" : "no"));
        Debug.Log("???");
    }

    void Update()
    {
        if (penObject != null)
        {
            Vector2 penPosition = penObject.transform.position;
            penPosition = Camera.main.WorldToScreenPoint(penPosition);

            Vector2 brushDirection = (penPosition - new Vector2(transform.position.x, transform.position.y)).normalized;
            float brushDistance = Vector2.Distance(penPosition, new Vector2(transform.position.x, transform.position.y));

            handwritingMaterial.SetFloat("_BrushSize", brushSize);
            handwritingMaterial.SetFloat("_Pressure", pressure);
            handwritingMaterial.SetVector("_BrushDirection", brushDirection);
            handwritingMaterial.SetFloat("_BrushDistance", brushDistance);
            Debug.Log("Brush direction: " + brushDirection);
            Debug.Log("Brush distance: " + brushDistance);
        }
        else
        {
            Debug.Log("Pen object not found");
        }
    }
}