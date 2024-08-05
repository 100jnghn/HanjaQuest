using BeyondLimitsStudios.VRInteractables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanjaModel : MonoBehaviour
{
    public GameObject[] hanjas;    // ���� ������Ʈ �迭
    public GameObject[] images;    // ���ڿ� �����ϴ� �̹��� �迭
    public GameObject completionCanvas; // ��� ���ڰ� �Ϸ�� �� ǥ���� ĵ����
    public GameObject posObject;

    public updateAccuracy accuracy;
    public mapMove mapMover;

    private int currentHanjaIndex = 0;  // ���� ǥ���� ���� �ε���
    private bool allHanjaComplete = false; // ��� ���� �Ϸ� ���� Ȯ��

    public AudioSource Answer;
    public AudioSource Clear;

    public Music m;


    void Start()
    {
        DisplayCurrentHanja(); // ���� ���� �� ù ��° ���ڿ� �̹����� ǥ��
    }

    void Update()
    {
        // �����̽��ٸ� ������ �� ���� ���ڷ� �̵�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextHanja();
        }
        // ��Ȯ���� 70 �̻��� �� ���� ���ڷ� �̵�
/*        if (accuracy.data.accuracy >= 5.0f && !allHanjaComplete)
        {
            NextHanja();
        }*/
    }

    // ���� �ε����� ���ڿ� �̹����� ȭ�鿡 ǥ��
    public void DisplayCurrentHanja()
    {
        updateAccuracy.zeroAccuracy();
        DrawingBoardTexture.clearAll();
        BrushCube.count();

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

            hanjas[currentHanjaIndex].SetActive(true);
            images[currentHanjaIndex].SetActive(true);
        }

    }

    // ���� ���� �� �̹����� �̵�
    public void NextHanja()
    {
        Answer.Play();
        // mapMove ��ũ��Ʈ���� �̵� ����
        if (mapMover != null)
        {
            mapMover.StartMove();
        }

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

    private IEnumerator ActivateCompletionCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        completionCanvas.SetActive(true);
        m.otherMusic.Stop();
        Clear.Play();
    }
}
