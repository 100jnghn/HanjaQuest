using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeyondLimitsStudios.VRInteractables;

public class HanjaSkill : MonoBehaviour
{
    private Animator animator;
    public static Action Activate;
    public GameObject fx;

    void Start()
    {
        animator = GetComponent<Animator>();
        Activate = () =>
        {
            ActivateSkill();
        };
    }

    public void ActivateSkill()
    {
        animator.SetTrigger("skillTrigger");
        fx.SetActive(true);
        DrawingBoardTexture.clearAll();

    }
    private IEnumerator deActivate()
    {
        yield return new WaitForSeconds(2f);
        fx.SetActive(false);
    }
}