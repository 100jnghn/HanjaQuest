using UnityEngine;

public class CubeCanvas : MonoBehaviour
{
    public GameObject brushCubePrefab;
    public int rows = 50;
    public int columns = 50;
    public float spacing = 0.05f;


    void Start()
    {
        GenerateCanvas();
    }

    public void GenerateCanvas()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = new Vector3(j * spacing, i * spacing, 0);
                Instantiate(brushCubePrefab, position, Quaternion.identity, transform);
            }
        }
    }
}
