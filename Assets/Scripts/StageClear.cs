using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    // Start is called before the first frame update
    public void SelectStage1()
    {
        SceneManager.LoadScene("SelectStage1");
    }

    public void SelectStage2()
    {
        SceneManager.LoadScene("SelectStage2");
    }

    public void SelectStage3()
    {
        SceneManager.LoadScene("SelectStage3");
    }
}
