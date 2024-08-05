using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public void LoadStage1()
    {
        // "Stage1-1" ¾À ·Îµå
        SceneManager.LoadScene("SelectStage1");
    }

    public void LoadStage2()
    {
        // "Stage1-2" ¾À ·Îµå
        SceneManager.LoadScene("SelectStage2");
    }

    public void LoadStage3()
    {
        // "Stage1-3" ¾À ·Îµå
        SceneManager.LoadScene("SelectStage3");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
