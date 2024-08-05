using System.Collections;
using UnityEngine;

public class Animator_Stage2 : MonoBehaviour
{
    public Animator animator;
    public string[] animationTriggers;
    private bool isAnimating = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatAnimationForDuration(10f)); // 10초 동안 애니메이션 반복
    }

    // Coroutine to repeat animations for a specific duration
    IEnumerator RepeatAnimationForDuration(float duration)
    {
        float startTime = Time.time; // 시작 시간 기록

        while (Time.time - startTime < duration && isAnimating) // duration 동안 반복
        {
            setAnimation(); // 애니메이션 설정
            yield return new WaitUntil(() => IsAnimationFinished()); // 현재 애니메이션이 끝날 때까지 대기
        }
    }

    // 무작위 애니메이션 트리거
    void setAnimation()
    {
        int rand = Random.Range(0, animationTriggers.Length); // 트리거 배열 길이에 맞춰 랜덤 인덱스 선택
        animator.SetTrigger(animationTriggers[rand]);
    }

    bool IsAnimationFinished()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // 현재 애니메이션 상태 정보 가져오기
        return stateInfo.normalizedTime >= 1 && !animator.IsInTransition(0); // 애니메이션이 끝났으면 true 반환
    }
}
