using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnswer : MonoBehaviour
{
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger entered");
        if (other.gameObject.CompareTag("character"))
        {
            Debug.Log("character entered");
            gameObject.tag = "answer";
            //cubeRenderer = GetComponent<Renderer>();
            cubeRenderer.material.color = Color.red;
        }
    }
}
