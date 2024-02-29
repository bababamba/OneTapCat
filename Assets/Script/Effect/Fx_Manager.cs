using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fx_Manager : MonoBehaviour
{
    public static Fx_Manager instance;


    public ItemGetFx prefabItem;
    public ItemGetFx prefabEffect;
    
    public Transform target;
    public Transform start;
    public RectTransform albumRect;
    private float PosX;
    public float initialScale = 0.2f;
    public float targetScale = 1f;
    public float targetScale2 = 0.95f;
    public float duration = 0.5f;
    private void Awake()
    {
        PosX = albumRect.localPosition.x;
        instance = this;
    }
    private void Start()
    {
       // GetItemFx(10);
    }
    public void GetItemFx(int randCount)
    {
        
        for (int i = 0; i < randCount; ++i)
        {
            var itemFx = GameObject.Instantiate<ItemGetFx>(prefabItem, this.transform);
            itemFx.transform.SetParent(this.transform);
            itemFx.Explosion(start.position, target.position, 500.0f);

            var EffectFx = GameObject.Instantiate<ItemGetFx>(prefabEffect, this.transform);
            EffectFx.transform.SetParent(this.transform);
            EffectFx.Explosion2(start.position, 500.0f);

        }
    }
    public void Ddoing(RectTransform rect)
    {
        rect.localScale = new Vector3(initialScale, initialScale, initialScale);
        rect.DOScale(new Vector3(targetScale, targetScale, targetScale), duration).SetEase(Ease.OutBack);

    }
    public void Ddoing2(RectTransform rect)
    {
        rect.localScale = new Vector3(initialScale, initialScale, initialScale);
        rect.DOScale(new Vector3(targetScale2, targetScale2, targetScale2), duration).SetEase(Ease.OutBack);

    }
    public void Gacha(RectTransform rect)
    {
        rect.localScale = new Vector3(initialScale, initialScale, initialScale);
        
        rect.DOScale(new Vector3(targetScale, targetScale, targetScale), duration).SetEase(Ease.OutBack);

    }
    public void Descend(RectTransform rect)
    {
        
        rect.localPosition = new Vector3(rect.localPosition.x-600f, rect.localPosition.y, rect.localPosition.z);
       rect.DOAnchorPosX(PosX,0.3f).SetEase(Ease.OutBack);

    }
    public void FadeOut(Image image)
    {
        image.DOFade(1f, 0.01f).SetEase(Ease.OutBack).OnComplete(()=> {
            image.DOFade(0f, 0.5f);
        });
        
    }

}
