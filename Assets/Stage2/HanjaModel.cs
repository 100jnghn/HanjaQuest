using BeyondLimitsStudios.VRInteractables;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using BeyondLimitsStudios.VRInteractables;


public class HanjaModel : MonoBehaviour
{
    public GameObject[] hanjas;    // ���� ������Ʈ �迭
    public GameObject[] images;    // ���ڿ� �����ϴ� �̹��� �迭
    public GameObject completionCanvas; // ��� ���ڰ� �Ϸ�� �� ǥ���� ĵ����
    public GameObject posObject;
    public TMP_Text showingCharacter;   // UI�� ǥ���� monster ���� ����
    public GameObject canvas; // Ŭ���� �� ��Ȱ��ȭ �� ĵ����
    public GameObject canvas2; // Ŭ���� �� ������ ���

    public updateAccuracy accuracy;
    public mapMove mapMover;

    private int currentHanjaIndex = 0;  // ���� ǥ���� ���� �ε���
    private bool allHanjaComplete = false; // ��� ���� �Ϸ� ���� Ȯ��

    public AudioSource Answer;
    public AudioSource Clear;

    public Music m;

    void Start()
    {
        showingCharacter.text = "";
        DisplayCurrentHanja(); // ���� ���� �� ù ��° ���ڿ� �̹����� ǥ��
    }

    void Update()
    {
        // �����̽��ٸ� ������ �� ���� ���ڷ� �̵�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(NextHanjaWithDelay());
        }
        // ��Ȯ���� ���� �̻��� �� ���� ���ڷ� �̵�
        if (accuracy != null && accuracy.data != null && accuracy.data.accuracy >= 0.3f)
        {
            StartCoroutine(NextHanjaWithDelay());
        }
    }

    // ���� �ε����� ���ڿ� �̹����� ȭ�鿡 ǥ��
    public void DisplayCurrentHanja()
    {
        // ��� ���ڿ� �̹����� ��Ȱ��ȭ
        foreach (var hanja in hanjas)
        {
            hanja.SetActive(false);
        }

        foreach (var image in images)
        {
            image.SetActive(false);
        }

        // ���� �ε����� ���ڿ� �̹����� Ȱ��ȭ
        if (currentHanjaIndex < hanjas.Length && currentHanjaIndex < images.Length)
        {
            Vector3 position = posObject.transform.position;

            // ���� �𵨰� �̹����� posObject ��ġ�� �̵�
            hanjas[currentHanjaIndex].transform.position = position;
            images[currentHanjaIndex].transform.position = position;

            showingCharacter.SetText(images[currentHanjaIndex].name);

            hanjas[currentHanjaIndex].SetActive(true);
            images[currentHanjaIndex].SetActive(true);
        }

    }

    // ���� ���� �� �̹����� �̵�
    public void NextHanja()
    {
        if (currentHanjaIndex < hanjas.Length - 1)
        {
            currentHanjaIndex++;
            DisplayCurrentHanja();
        }
        else
        {
            // �ε����� �迭�� ���� �����ϸ� �Ϸ� ĵ������ 2�� �ڿ� Ȱ��ȭ
            if (completionCanvas != null)
            {
                StartCoroutine(ActivateCompletionCanvasAfterDelay(2f));
            }
            allHanjaComplete = true; // ��� ���ڰ� �Ϸ�Ǿ����� ǥ��
        }
    }

    private IEnumerator NextHanjaWithDelay()
    {
        BoardScript.SetTex(); //�ؽ��� ����
        HanjaSkill.Activate(); //�ִϸ��̼� ���

        updateAccuracy.zeroAccuracy();
        DrawingBoardTexture.clearAll();
        DrawTest.initAnswer();
        BrushCube.count();

        // Answer.Play()�� ��� ����
        Answer.Play();
        // mapMove ��ũ��Ʈ���� �̵� ����
        if (mapMover != null)
        {
            mapMover.StartMove();
        }
        // 1�� ��� �� NextHanja ����
        yield return new WaitForSeconds(1f);
        NextHanja();
    }

    private IEnumerator ActivateCompletionCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvas.SetActive(false);
        canvas2.SetActive(true);
        completionCanvas.SetActive(true);
        m.otherMusic.Stop();
        Clear.Play();
    }
}
