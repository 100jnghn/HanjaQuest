using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public RabbitGameManager rabbitGameManger;
    public GameObject[] enemy;      // 3 stage -> Rabbit

    private Transform originPos;    // 포지션이 nav때매 변해서 원래 포지션 저장

    public float minSpawnTime;  // 최소 스폰 시간
    public float maxSpawnTime;  // 최대 스폰 시간 // min ~ max
    public CurrentGameData Gdata;
    public Data data;
    public Transform modelSpawnPos;
    public LinkData linkData;

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
        string hanjaName = Gdata.HanjaName;
        foreach (DictionaryEntry<string, Data> entry in linkData.hanjaDataList)
        {

            if (entry.key == hanjaName)
            {
                data = entry.value;
                break;
            }
        }

        Instantiate(enemy[randomIdx], originPos.position, originPos.rotation);
        Instantiate(data.model, modelSpawnPos.position, modelSpawnPos.rotation);
        //rabbitGameManger.enqueue(newRabbit);
    }
}
