using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    RabbitGameManager rabbitGameManager;
    NavMeshAgent navigation;
    Animator animator;

    string[] characterArr =
    {
        "달월",
        "불화",
        "물수",
        "나무목",
        "불금",
        "흙토",
        "날일"
    };

    public GameObject target;
    public string ownCharacter;    


    void Awake()
    {
        rabbitGameManager = GameObject.Find("RabbitGameManager").GetComponent<RabbitGameManager>();
        navigation = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        target = GameObject.Find("TargetPosition");
        ownCharacter = characterArr[Random.Range(0, characterArr.Length)];
    }

    void Start()
    {
        rabbitGameManager.enqueue(gameObject);    
    }

    void Update()
    {
        navigation.SetDestination(target.transform.position);
    }

    void OnDestroy()
    {
        rabbitGameManager.dequeue();    
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
