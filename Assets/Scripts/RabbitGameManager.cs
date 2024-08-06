using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using BeyondLimitsStudios.VRInteractables;
using UnityEngine.UI;
using UnityEngine.InputSystem.Composites;
using System.Security.Cryptography;

public class RabbitGameManager : MonoBehaviour
{
    public Queue<GameObject> monsterQ;  // ���� �ִ� monster�� �����ϴ� ť

    public GameObject drawHanjaCanvas;  // ���� �׸��� ĵ����
    public GameObject clearPanel;   // Ŭ���� �� ���� UI �г�
    public GameObject failpanel;    // ���� �� ���� UI �г�

    public GameObject spawnPoint;   // rabbit monster ���� ��ġ
    public CarrotBox carrotBox;     // ��� ���� -> ����� �� count 
    public TMP_Text showingCharacter;   // UI�� ǥ���� monster ���� ����
    public Text remainTimeText;     // ���� �ð� ǥ���ϴ� �ؽ�Ʈ
    public Text remainCarrotText;   // ���� ��� ǥ���ϴ� �ؽ�Ʈ
    public Timer timer;             // Ÿ�̸� (���� �ð�) 

    public AudioSource bgm;         // ���� bgm
    public AudioSource clearSound;  // ���� ȿ����
    public AudioSource failSound;   // ���� ȿ����
    public GameObject[] hanjas;
    public GameObject[] Images;

    //public GameObject hanjaPos;

    public updateAccuracy updateAccuracy;   // ��Ȯ���� �������� ���� ����
    public float dieScore;                  // dieScore �̻��̸� monster �׽��ϴ�

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

        remainCarrotText.text = "���� ���: " + carrotBox.carrotCount.ToString();

        // ��� �� �и��� ���� ����
        if (carrotBox.carrotCount <= 0)
        {
            if (isGaming)
            {
                gameOver();

                // ���� UI
                failpanel.SetActive(true);

                // ���� sfx
                failSound.Play();
            }           
        }

        // ���� �ð� ǥ��
        remainTimeText.text = "���� �ð�: " + ((int)timer.remainTime).ToString();

        // ���� �ð� ����(Ŭ����)
        if (timer.remainTime <= 0)
        {
            if (isGaming)
            {
                gameOver();

                // Ŭ���� UI
                clearPanel.SetActive(true);

                // Ŭ���� sfx
                clearSound.Play();
            }
        }

        // dieScore �̻��̸� Monster �׿�����
        checkAccuracy();
    }

    // ���� ����
    public void gameStart()
    {
        isGaming = true;
        spawnPoint.SetActive(true);
        timer.isStarting = true;
        drawHanjaCanvas.SetActive(true);
        bgm.Play();
    }

    // ���� ���� (�̿�)
    public void gameOver()
    {
        isGaming = false;
        timer.isStarting = false;
        drawHanjaCanvas.SetActive(false);
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

            showingCharacter.SetText(nMonster.ownCharacter);
            FindHanja(nMonster.ownCharacter);

            // ��Ȯ�� 0���� �ʱ�ȭ
            updateAccuracy.zeroAccuracy();
        }
    }

    // ��Ȯ���� n�̻��� �� mosnter ����
    void checkAccuracy()
    {
        if (isGaming && monsterQ.Count > 0)
        {
            if (updateAccuracy.data.accuracy > dieScore)
            {
                GameObject firstMonster = monsterQ.Peek();
                Monster nMonster = firstMonster.GetComponent<Monster>();
                nMonster.die();
            }
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
                //Images[0].SetActive(true);
                break;
            case "�� ȭ":
                //nstantiate(hanjas[1], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[1].SetActive(true);
                //Images[1].SetActive(true);
                break;
            case "�� ��":
                //Instantiate(hanjas[2], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[2].SetActive(true);
                //Images[2].SetActive(true);
                break;
            case "���� ��":
                //Instantiate(hanjas[3], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[3].SetActive(true);
                //Images[3].SetActive(true);
                break;
            case "�� ��":
                //Instantiate(hanjas[4], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[4].SetActive(true);
                //Images[4].SetActive(true);
                break;
            case "�� ��":
                //Instantiate(hanjas[5], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[5].SetActive(true);
                //Images[5].SetActive(true);
                break;
            case "�� ��":
                //Instantiate(hanjas[6], hanjaPos.transform.position, hanjaPos.transform.rotation);
                hanjas[6].SetActive(true);
                //Images[6].SetActive(true);
                break;
        }
        DrawingBoardTexture.clearAll();
        BrushCube.count();
        DrawTest.initAnswer();
        DrawTest.initTmp();

        /*foreach (Transform child in transform)
        {
            Debug.Log(child.gameObject.name);
            child.gameObject.tag = "miss";
            Renderer renderer = child.GetComponent<Renderer>();
            renderer.material.color = Color.white;

        }
        for (int i = 0; i < 2500; i++)
        {
            transform.GetChild(i).gameObject.tag="miss";
            Renderer renderer = transform.GetChild(i).GetComponent<Renderer>();
            renderer.material.color = Color.white;
        }
        */
        //Invoke("BrushCube.count()", 1f);
    }


    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
