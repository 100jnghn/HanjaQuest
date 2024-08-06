using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterStage : MonoBehaviour
{
    //public GameObject StageUI; // Æ÷Å» UI ÆÐ³Î GameObject
    
    private void Start()
    {
        //StageUI.SetActive(false);
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Æ÷Å» UI ÆÐ³Î È°¼ºÈ­
            //StageUI.SetActive(true);
        }

        else
        {
            //StageUI.SetActive(false);
        }
    }*/

    public void LoadStage1_1()
    {
        // "Stage1-1" ¾À ·Îµå
        SceneManager.LoadScene("Stage1-1");
    }

    public void LoadStage1_2()
    {
        // "Stage1-2" ¾À ·Îµå
        SceneManager.LoadScene("Stage1-2");
    }

    public void LoadStage1_3()
    {
        // "Stage1-3" ¾À ·Îµå
        SceneManager.LoadScene("Stage1-3");
    }

    public void LoadStage2_1()
    {
        // "Stage2-1" ¾À ·Îµå
        SceneManager.LoadScene("Stage 2-1");
    }

    public void LoadStage2_2()
    {
        // "Stage2-2" ¾À ·Îµå
        SceneManager.LoadScene("Stage2-2");
    }

    public void LoadStage2_3()
    {
        // "Stage2-3" ¾À ·Îµå
        SceneManager.LoadScene("Stage2-3");
    }

    public void LoadStage3_1()
    {
        // "Stage3-1" ¾À ·Îµå
        SceneManager.LoadScene("Stage3-1");
    }

    public void LoadStage3_2()
    {
        // "Stage3-2" ¾À ·Îµå
        SceneManager.LoadScene("Stage3-2");
    }

    public void LoadStage3_3()
    {
        // "Stage3-3" ¾À ·Îµå
        SceneManager.LoadScene("Stage3-3");
    }

    public void LoadJohnny()
    {
        // "Johnny" ¾À ·Îµå
        SceneManager.LoadScene("Johnny");
    }
}
