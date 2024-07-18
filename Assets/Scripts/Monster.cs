using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    NavMeshAgent navigation;
    Animator animator;

    string[] characterArr =
    {
        "�޿�",
        "��ȭ",
        "����",
        "������",
        "�ұ�",
        "����",
        "����"
    };

    public GameObject target;
    public string ownCharacter;    


    void Awake()
    {
        navigation = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        target = GameObject.Find("TargetPosition");
        ownCharacter = characterArr[Random.Range(0, characterArr.Length)];
    }

    void Update()
    {
        navigation.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AttackTarget"))
        {
            transform.LookAt(collision.transform.position);
            animator.SetBool("isAttack", true);
        }
    }

    public void die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 1.5f);
    }
}
