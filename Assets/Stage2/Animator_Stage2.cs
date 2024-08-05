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
        StartCoroutine(RepeatAnimationForDuration(10f)); // 10�� ���� �ִϸ��̼� �ݺ�
    }

    // Coroutine to repeat animations for a specific duration
    IEnumerator RepeatAnimationForDuration(float duration)
    {
        float startTime = Time.time; // ���� �ð� ���

        while (Time.time - startTime < duration && isAnimating) // duration ���� �ݺ�
        {
            setAnimation(); // �ִϸ��̼� ����
            yield return new WaitUntil(() => IsAnimationFinished()); // ���� �ִϸ��̼��� ���� ������ ���
        }
    }

    // ������ �ִϸ��̼� Ʈ����
    void setAnimation()
    {
        int rand = Random.Range(0, animationTriggers.Length); // Ʈ���� �迭 ���̿� ���� ���� �ε��� ����
        animator.SetTrigger(animationTriggers[rand]);
    }

    bool IsAnimationFinished()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // ���� �ִϸ��̼� ���� ���� ��������
        return stateInfo.normalizedTime >= 1 && !animator.IsInTransition(0); // �ִϸ��̼��� �������� true ��ȯ
    }
}
