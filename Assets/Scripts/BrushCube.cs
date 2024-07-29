using System.Diagnostics;
using UnityEngine;

public class BrushCube : MonoBehaviour
{
    public Data data;
    private Renderer cubeRenderer;
    private bool flag = false;
    public float DifficultyFactor = 0.03f; //³·¾ÆÁú¼ö·Ï ½¬¿öÁü

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        if (gameObject.tag == "answer")
        {
            cubeRenderer.material.color = Color.red;
            data.missedCube++;
            data.totalAnswerCube++;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pen"))
        {
            //cubeRenderer.material.color = Color.black;
            
            if (gameObject.tag =="answer" && flag == false)
            {
                data.correctCube++;
                data.missedCube--;
            }
            else if(gameObject.tag =="miss" && flag == false)
            {
                data.wrongCube++;
            }
            Calculate();
            flag = true;
        }

    }
    public void Calculate()
    {
        if (data.totalAnswerCube == 0) data.accuracy = 0;

        data.accuracy = ((float)data.correctCube - ((float)data.wrongCube*DifficultyFactor)) / (float)data.totalAnswerCube * 100f;
       // UnityEngine.Debug.Log(data.accuracy);
        //return data.accuracy;
    }
    void Update()
    {

    }
}
