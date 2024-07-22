using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RabbitGameManager : MonoBehaviour
{
    public Queue<GameObject> monsterQ;  // ���� �ִ� monster�� �����ϴ� ť

    public GameObject spawnPoint;   // rabbit monster ���� ��ġ
    public CarrotBox carrotBox;     // ��� ���� -> ����� �� count 
    public Text showingCharacter;   // UI�� ǥ���� monster ���� ����
    public Text remainTimeText;     // ���� �ð� ǥ���ϴ� �ؽ�Ʈ
    public Timer timer;             // Ÿ�̸� (���� �ð�) 

    bool isGaming;



    void Start()
    {
        monsterQ = new Queue<GameObject>();
    }

    void Update()
    {
        // ť�� ������� ���� ǥ�� X
        if(monsterQ.Count == 0)
        {
            showingCharacter.text = "";
        }

        // ��� �� �и��� ���� ����
        if(carrotBox.carrotCount <= 0)
        {
            isGaming = false;
            gameOver();
        }

        // ���� �ð� ǥ��
        remainTimeText.text = "���� �ð�:" + ((int)timer.remainTime).ToString();

        // ���� �ð� ����(Ŭ����)
        if (timer.remainTime <= 0)
        {
            gameOver();
        }
    }

    // ���� ����
    public void gameStart()
    {
        isGaming = true;
        spawnPoint.SetActive(true);
        timer.isStarting = true;
    }

    // ���� ���� (�̿�)
    public void gameOver()
    {
        isGaming = false;
        timer.isStarting = false;

        Destroy(spawnPoint);
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

    // UI�� ǥ���� ���� update
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
