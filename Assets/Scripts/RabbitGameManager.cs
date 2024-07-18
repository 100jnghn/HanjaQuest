using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RabbitGameManager : MonoBehaviour
{
    public Queue<GameObject> monsterQ;
    bool isGaming;

    public GameObject spawnPoint;
    public Text showingCharacter; // UI�� ǥ���� monster ���� ����

    void Start()
    {
        monsterQ = new Queue<GameObject>();
    }

    void Update()
    {

    }

    public void gameStart()
    {
        isGaming = true;
        spawnPoint.SetActive(true);
    }

    public void enqueue(GameObject rabbit)  // ť�� ���� push()
    {
        monsterQ.Enqueue(rabbit);

        // ť�� ó������ mosnter ����
        if(monsterQ.Count == 1)
        {
            Debug.Log("MonsterQ 1");
            updateCharacter();
        }
    }

    public void dequeue()   // ť���� ���� pop()
    {
        if (monsterQ.Count > 0)
        {
            monsterQ.Dequeue();
            updateCharacter();
        }
    }

    void updateCharacter()
    {
        GameObject firstMonster = monsterQ.Peek();
        Monster nMonster = firstMonster.GetComponent<Monster>();
        Debug.Log(nMonster.ownCharacter);

        showingCharacter.text = nMonster.ownCharacter;
    }

}
