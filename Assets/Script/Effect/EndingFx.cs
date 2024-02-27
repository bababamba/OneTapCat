using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EndingFx : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform targetRectTransform; // 대상 UI의 RectTransform
    public Vector2[] targetPosition; // 목표 위치 설정
    public Image image;
    Sequence sequence;
    [SerializeField] Video_Ad VAds;
    [SerializeField] GameObject EndingFxObject;
    int temp = 0;
    void Start()
    {
        
        
        

    }
    public void RunEffect()
    {
        StartCoroutine(EndingEffect());
    }
    IEnumerator EndingEffect()
    {
        temp = 0;

        sequence = DOTween.Sequence().SetLoops(4, LoopType.Restart);
        sequence.Append(image.DOFade(1f, 0.5f));
        sequence.Append(image.DOFade(0f, 0.5f));
        foreach (Vector2 pos in targetPosition)
        {
            
            image.sprite = Main_Manager.instance.Main_Sprite[(Main_Manager.instance.stage-1) * 4 + temp++];

            targetRectTransform.DOAnchorPos(pos, 1.0f).SetEase(Ease.OutQuad);
            yield return new WaitForSeconds(1f);


        }
        if (!Main_Manager.instance.NoAds)
            VAds.ShowAd();

        EndingFxObject.SetActive(false);
    }
}
