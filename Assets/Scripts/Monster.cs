using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    NavMeshAgent navigation;

    public Transform target;


    void Start()
    {
        navigation = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navigation.SetDestination(target.position);
    }
}
