using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TurnAround : MonoBehaviour
{
    public Image targetImage;
    public float rotationAmount = 360f;
    public float duration = 5.0f;
    private void Start()
    {
        targetImage.rectTransform.DORotate(new Vector3(0f, 0f, rotationAmount), duration, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
    }
}
