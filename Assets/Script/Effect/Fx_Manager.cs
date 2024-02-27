using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fx_Manager : MonoBehaviour
{
    public static Fx_Manager instance;


    public ItemGetFx prefabItem;
    public ItemGetFx prefabEffect;
    
    public Transform target;
    public Transform start;

    public float initialScale = 0.2f;
    public float targetScale = 0.95f;
    public float duration = 0.5f;
    private void Awake()
    {
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
    public void Gacha(RectTransform rect)
    {
        rect.localScale = new Vector3(initialScale, initialScale, initialScale);
        
        rect.DOScale(new Vector3(targetScale, targetScale, targetScale), duration).SetEase(Ease.OutBack);

    }

}
