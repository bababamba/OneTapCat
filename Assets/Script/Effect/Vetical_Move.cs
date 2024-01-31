using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vetical_Move : MonoBehaviour
{
    public float speed = 15f; // 움직이는 속도

    [SerializeField] RectTransform rectTransform;
    float BaseY;
    private void Start()
    {
        
        rectTransform = GetComponent<RectTransform>();
        BaseY = rectTransform.anchoredPosition.y;
        // 코루틴 시작
        StartCoroutine(MoveUpDown());
    }

    private IEnumerator MoveUpDown()
    {
        while (true)
        {
            float newY = Mathf.PingPong(Time.time * speed, 20f) - 10f; // PingPong 함수를 사용하여 위아래로 이동
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, BaseY+newY);

            yield return null; // 한 프레임 기다림
        }
    }
}
