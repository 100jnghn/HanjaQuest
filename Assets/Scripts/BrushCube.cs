using UnityEngine;

public class BrushCube : MonoBehaviour
{
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pen"))
        {
            cubeRenderer.material.color = Color.black;
        }
    }
}
