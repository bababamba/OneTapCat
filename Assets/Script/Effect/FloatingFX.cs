using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingFX : MonoBehaviour
{
    public RectTransform targetRectTransform;
    public float FloatingDistance;
    public float duration = 1.0f;
    float initialScale = 0.2f;
    float targetScale = 0.6f;
    public float speed = 15f; // �����̴� �ӵ�
    float BaseY;

    void Start()
    {

        // �ʱ� ��ġ �� ũ�� ����
        float initialY = targetRectTransform.anchoredPosition.y;

        // ���� ����ϸ鼭 Ŀ���� �ִϸ��̼� ����
        targetRectTransform.DOAnchorPosY(initialY + FloatingDistance, duration);
        targetRectTransform.localScale = new Vector3(initialScale, initialScale, initialScale);
        targetRectTransform.DOScale(new Vector3(targetScale, targetScale, targetScale), duration).SetEase(Ease.OutBack).OnComplete(
            ()=> { 
                BaseY = targetRectTransform.anchoredPosition.y; 
                if(targetRectTransform.gameObject.transform.parent.gameObject.activeSelf)
                StartCoroutine(MoveUpDown()); 
            });       
        // �ڷ�ƾ ����
        

    }
    private IEnumerator MoveUpDown()
    {
        while (true)
        {
            float newY = Mathf.PingPong(Time.time * speed, 20f) - 10f; // PingPong �Լ��� ����Ͽ� ���Ʒ��� �̵�
            targetRectTransform.anchoredPosition = new Vector2(targetRectTransform.anchoredPosition.x, BaseY + newY);

            yield return null; // �� ������ ��ٸ�
        }
    }
}
