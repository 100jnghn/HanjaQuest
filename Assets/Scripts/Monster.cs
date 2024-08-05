using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    RabbitGameManager rabbitGameManager;
    NavMeshAgent navigation;
    Animator animator;

    public AudioSource moveSound;   // 토끼 점프하는 소리
    public AudioSource dieSound;    // 토끼 죽는 소리
    public AudioSource eatSound;    // 토끼 밥 먹는 소리

    string[] characterArr =
    {
        "달 월",
        "불 화",
        "물 수",
        "나무 목",
        "불 금",
        "흙 토",
        "날 일"
    };

    GameObject target;
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
        if (rabbitGameManager.isGaming)
        {
            navigation.SetDestination(target.transform.position);
        }
        else
        {
            navigation.isStopped = true;
        }
    }

    void OnDestroy()
    {
        rabbitGameManager.dequeue();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AttackTarget"))
        {
            stopMoveSound();

            if (!eatSound.isPlaying)
            {
                eatSound.Play();
            }

            transform.LookAt(collision.transform.position);
            animator.SetBool("isAttack", true);
        }
    }

    public void die()
    {
        stopMoveSound();
        dieSound.Play();

        animator.SetTrigger("Die");
        Destroy(gameObject, 1.5f);
    }

    void stopMoveSound()
    {
        if (moveSound.isPlaying)
        {
            moveSound.Stop();
        }
    }
}
