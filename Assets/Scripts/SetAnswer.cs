using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnswer : MonoBehaviour
{
    private Renderer cubeRenderer;

    void Start()
    {
        //cubeRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("character"))
        {           
            gameObject.tag = "answer";
        }
    }
}
