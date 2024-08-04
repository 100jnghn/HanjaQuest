using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClickSound : MonoBehaviour
{
    public AudioSource clickButton;

    public void ButtonClicked()
    {
        clickButton.Play();
    }
}
