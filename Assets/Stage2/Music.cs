using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource backgroundMusic; // 배경 음악 오디오 소스
    public AudioSource otherMusic;      // 다른 음악 오디오 소스

    // 배경 음악을 재생
    void Start()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Play(); // 배경 음악 재생
        }
    }

    // 배경 음악을 끄고 다른 음악 재생
    public void PlayOtherMusic()
    {
        if (backgroundMusic != null && otherMusic != null)
        {
            // 배경 음악 중지
            backgroundMusic.Stop();

            // 다른 음악 재생
            otherMusic.Play();
        }
    }
}