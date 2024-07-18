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
    public Text showingCharacter; // UI에 표시할 monster 고유 한자

    void Start()
    {
        monsterQ = new Queue<GameObject>();
    }

    void Update()
    {
        if(monsterQ.Count == 0)
        {
            showingCharacter.text = "";
        }
    }

    public void gameStart()
    {
        isGaming = true;
        spawnPoint.SetActive(true);
    }

    public void enqueue(GameObject rabbit)  // 큐에 몬스터 push()
    {
        monsterQ.Enqueue(rabbit);

        // 큐에 처음으로 mosnter 들어옴
        if(monsterQ.Count == 1)
        {
            Debug.Log("MonsterQ 1");
            updateCharacter();
        }
    }

    public void dequeue()   // 큐에서 몬스터 pop()
    {
        if (monsterQ.Count > 0)
        {
            monsterQ.Dequeue();
            updateCharacter();
        }
    }

    void updateCharacter()
    {
        if (monsterQ.Count > 0)
        {
            GameObject firstMonster = monsterQ.Peek();
            Monster nMonster = firstMonster.GetComponent<Monster>();
            Debug.Log(nMonster.ownCharacter);

            showingCharacter.text = nMonster.ownCharacter;
        }       
    }

}
