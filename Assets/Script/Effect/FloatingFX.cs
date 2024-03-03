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
    public float speed = 15f; // 움직이는 속도
    float BaseY;

    void Start()
    {

        // 초기 위치 및 크기 저장
        float initialY = targetRectTransform.anchoredPosition.y;

        // 위로 상승하면서 커지는 애니메이션 설정
        targetRectTransform.DOAnchorPosY(initialY + FloatingDistance, duration);
        targetRectTransform.localScale = new Vector3(initialScale, initialScale, initialScale);
        targetRectTransform.DOScale(new Vector3(targetScale, targetScale, targetScale), duration).SetEase(Ease.OutBack).OnComplete(
            ()=> { 
                BaseY = targetRectTransform.anchoredPosition.y; 
                if(targetRectTransform.gameObject.transform.parent.gameObject.activeSelf)
                StartCoroutine(MoveUpDown()); 
            });       
        // 코루틴 시작
        

    }
    private IEnumerator MoveUpDown()
    {
        while (true)
        {
            float newY = Mathf.PingPong(Time.time * speed, 20f) - 10f; // PingPong 함수를 사용하여 위아래로 이동
            targetRectTransform.anchoredPosition = new Vector2(targetRectTransform.anchoredPosition.x, BaseY + newY);

            yield return null; // 한 프레임 기다림
        }
    }
}
