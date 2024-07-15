using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitGameManager : MonoBehaviour
{
    Queue<GameObject> monsterQ;
    bool isGaming;

    public GameObject spawnPoint;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void gameStart()
    {
        isGaming = true;
        spawnPoint.SetActive(true);
    }

    public void enqueue(GameObject rabbit)
    {
        monsterQ.Enqueue(rabbit);
    }

    public void dequeue()
    {
        if (monsterQ.Count > 0)
        {
            monsterQ.Dequeue();
        }
    }

}
