using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    // Start is called before the first frame update
    public void Clear()
    {
        SceneManager.LoadScene("SelectStage1");
    }
}
