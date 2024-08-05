using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource backgroundMusic; // ��� ���� ����� �ҽ�
    public AudioSource otherMusic;      // �ٸ� ���� ����� �ҽ�

    // ��� ������ ���
    void Start()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Play(); // ��� ���� ���
        }
    }

    // ��� ������ ���� �ٸ� ���� ���
    public void PlayOtherMusic()
    {
        if (backgroundMusic != null && otherMusic != null)
        {
            // ��� ���� ����
            backgroundMusic.Stop();

            // �ٸ� ���� ���
            otherMusic.Play();
        }
    }
}