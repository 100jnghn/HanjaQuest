using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public RabbitGameManager rabbitGameManger;
    public GameObject[] enemy;      // 3 stage -> Rabbit

    private Transform originPos;    // 포지션이 nav때매 변해서 원래 포지션 저장

    public float minSpawnTime;  // 최소 스폰 시간
    public float maxSpawnTime;  // 최대 스폰 시간 // min ~ max
   

    void Start()
    {
        originPos = transform;
        InvokeRepeating("spawn", 3f, Random.Range(minSpawnTime, maxSpawnTime));
    }

    void Update()
    {
        
    }

    void spawn()
    {
        int randomIdx = Random.Range(0, enemy.Length);
       

        Instantiate(enemy[randomIdx], originPos.position, originPos.rotation);
        //rabbitGameManger.enqueue(newRabbit);
    }
}
