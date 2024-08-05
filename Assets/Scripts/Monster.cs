using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    RabbitGameManager rabbitGameManager;
    NavMeshAgent navigation;
    Animator animator;

    public AudioSource moveSound;   // Åä³¢ Á¡ÇÁÇÏ´Â ¼Ò¸®
    public AudioSource dieSound;    // Åä³¢ Á×´Â ¼Ò¸®
    public AudioSource eatSound;    // Åä³¢ ¹ä ¸Ô´Â ¼Ò¸®

    string[] characterArr =
    {
        "´Þ ¿ù",
        "ºÒ È­",
        "¹° ¼ö",
        "³ª¹« ¸ñ",
        "¼è ±Ý",
        "Èë Åä",
        "³¯ ÀÏ"
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
            stopMoveSound();
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
