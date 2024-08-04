using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RabbitGameManager : MonoBehaviour
{
    public Queue<GameObject> monsterQ;  // ���� �ִ� monster�� �����ϴ� ť

    public AudioSource bgm;         // ���� bgm

    public GameObject clearPanel;   // Ŭ���� �� ���� UI �г�
    public GameObject failpanel;    // ���� �� ���� UI �г�

    public GameObject spawnPoint;   // rabbit monster ���� ��ġ
    public CarrotBox carrotBox;     // ��� ���� -> ����� �� count 
    public Text showingCharacter;   // UI�� ǥ���� monster ���� ����
    public Text remainTimeText;     // ���� �ð� ǥ���ϴ� �ؽ�Ʈ
    public Timer timer;             // Ÿ�̸� (���� �ð�) 
    

    public GameObject[] hanjas;
    public GameObject hanjaPos;

    public bool isGaming;


    void Start()
    {
        monsterQ = new Queue<GameObject>();
    }

    void Update()
    {
        // ť�� ������� ���� ǥ�� X
        if (monsterQ.Count == 0)
        {
            showingCharacter.text = "";
        }

        // ��� �� �и��� ���� ����
        if (carrotBox.carrotCount <= 0)
        {
            isGaming = false;
            gameOver();

            // ���� UI
            failpanel.SetActive(true);
        }

        // ���� �ð� ǥ��
        remainTimeText.text = "���� �ð�:" + ((int)timer.remainTime).ToString();

        // ���� �ð� ����(Ŭ����)
        if (timer.remainTime <= 0)
        {
            gameOver();

            // Ŭ���� UI
            clearPanel.SetActive(true);
        }
    }

    // ���� ����
    public void gameStart()
    {
        isGaming = true;
        spawnPoint.SetActive(true);
        timer.isStarting = true;
        bgm.Play();
    }

    // ���� ���� (�̿�)
    public void gameOver()
    {
        isGaming = false;
        timer.isStarting = false;
        bgm.Stop();
        Destroy(spawnPoint);
    }

    public void enqueue(GameObject rabbit)  // ť�� ���� push()
    {
        monsterQ.Enqueue(rabbit);

        // ť�� ó������ mosnter ����
        if (monsterQ.Count == 1)
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
            FindHanja(nMonster.ownCharacter);
        }
        
        

    }

    void FindHanja(string name)
    {
        switch (name)
        {
            case "�� ��":
                Instantiate(hanjas[0], hanjaPos.transform.position, hanjaPos.transform.rotation);
                break;
            case "�� ȭ":
                Instantiate(hanjas[1], hanjaPos.transform.position, hanjaPos.transform.rotation);
                break;
            case "�� ��":
                Instantiate(hanjas[2], hanjaPos.transform.position, hanjaPos.transform.rotation);
                break;
            case "���� ��":
                Instantiate(hanjas[3], hanjaPos.transform.position, hanjaPos.transform.rotation);
                break;
            case "�� ��":
                Instantiate(hanjas[4], hanjaPos.transform.position, hanjaPos.transform.rotation);
                break;
            case "�� ��":
                Instantiate(hanjas[5], hanjaPos.transform.position, hanjaPos.transform.rotation);
                break;
            case "�� ��":
                Instantiate(hanjas[6], hanjaPos.transform.position, hanjaPos.transform.rotation);
                break;
        }
        BrushCube.count();
        //Invoke("BrushCube.count()", 1f);
    }


    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
