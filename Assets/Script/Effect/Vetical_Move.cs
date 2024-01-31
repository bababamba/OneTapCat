using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vetical_Move : MonoBehaviour
{
    public float speed = 15f; // �����̴� �ӵ�

    [SerializeField] RectTransform rectTransform;
    float BaseY;
    private void Start()
    {
        
        rectTransform = GetComponent<RectTransform>();
        BaseY = rectTransform.anchoredPosition.y;
        // �ڷ�ƾ ����
        StartCoroutine(MoveUpDown());
    }

    private IEnumerator MoveUpDown()
    {
        while (true)
        {
            float newY = Mathf.PingPong(Time.time * speed, 20f) - 10f; // PingPong �Լ��� ����Ͽ� ���Ʒ��� �̵�
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, BaseY+newY);

            yield return null; // �� ������ ��ٸ�
        }
    }
}
