using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using BeyondLimitsStudios.VRInteractables;
using UnityEngine.UI;

public class RabbitGameManager : MonoBehaviour
{
    public Queue<GameObject> monsterQ;  // ���� �ִ� monster�� �����ϴ� ť

    public GameObject clearPanel;   // Ŭ���� �� ���� UI �г�
    public GameObject failpanel;    // ���� �� ���� UI �г�

    public GameObject spawnPoint;   // rabbit monster ���� ��ġ
    public CarrotBox carrotBox;     // ��� ���� -> ����� �� count 
    public Text showingCharacter;   // UI�� ǥ���� monster ���� ����
    public Text remainTimeText;     // ���� �ð� ǥ���ϴ� �ؽ�Ʈ
    public Timer timer;             // Ÿ�̸� (���� �ð�) 

    public GameObject[] hanjas;
    public GameObject[] Images;

    //public GameObject hanjaPos;

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
        for (int i = 0; i < hanjas.Length; i++)
        {
            hanjas[i].SetActive(false);
            Images[i].SetActive(false);
        }
        switch (name)
        {
            case "�� ��":
                hanjas[0].SetActive(true);
                Images[0].SetActive(true);
                break;
            case "�� ȭ":
                //nstantiate(hanjas[1], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[1].SetActive(true);
                Images[1].SetActive(true);
                break;
            case "�� ��":
                //Instantiate(hanjas[2], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[2].SetActive(true);
                Images[2].SetActive(true);
                break;
            case "���� ��":
                //Instantiate(hanjas[3], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[3].SetActive(true);
                Images[3].SetActive(true);
                break;
            case "�� ��":
                //Instantiate(hanjas[4], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[4].SetActive(true);
                Images[4].SetActive(true);
                break;
            case "�� ��":
                //Instantiate(hanjas[5], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[5].SetActive(true);
                Images[5].SetActive(true);
                break;
            case "�� ��":
                //Instantiate(hanjas[6], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[6].SetActive(true);
                Images[6].SetActive(true);
                break;
        }
        DrawingBoardTexture.clearAll();
        BrushCube.count();
        
        //Invoke("BrushCube.count()", 1f);
    }


    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
