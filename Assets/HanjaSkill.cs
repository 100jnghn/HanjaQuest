using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeyondLimitsStudios.VRInteractables;

public class HanjaSkill : MonoBehaviour
{
    private Animator animator;
    public static Action Activate;


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
        DrawingBoardTexture.clearAll();
    }
}