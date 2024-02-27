using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class SlowBlinkingText : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float fadeInDuration = 1.0f;
    public float fadeOutDuration = 1.0f;
    public float delayBetweenBlinks = 1.0f;

    void Start()
    {
        // 초기 투명도 설정
        textMeshPro.alpha = 0f;

        // 깜빡이는 애니메이션 설정
        Sequence blinkSequence = DOTween.Sequence();
        blinkSequence.Append(textMeshPro.DOFade(1f, fadeInDuration));
        blinkSequence.AppendInterval(delayBetweenBlinks);
        blinkSequence.Append(textMeshPro.DOFade(0f, fadeOutDuration));
        blinkSequence.SetLoops(-1); // 무한 반복
    }
}