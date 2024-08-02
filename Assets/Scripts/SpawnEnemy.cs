using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public RabbitGameManager rabbitGameManger;
    public GameObject[] enemy;      // 3 stage -> Rabbit

    private Transform originPos;    // �������� nav���� ���ؼ� ���� ������ ����

    public float minSpawnTime;  // �ּ� ���� �ð�
    public float maxSpawnTime;  // �ִ� ���� �ð� // min ~ max
   

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
