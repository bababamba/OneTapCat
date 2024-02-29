using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using Random = System.Random;
using TMPro;
public class vibrateCan : MonoBehaviour
{
    public Image targetImage;
    public float vibrateStrength = 10f;
    public float duration = 2.0f;
    private Tweener rotater;
    [SerializeField] Sprite[] sprites;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject Peresto;

    Sequence sequence;

    public float initialScale = 0.2f;
    public float targetScale = 1.0f;
    Random r = new Random();

    bool clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        rotater = targetImage.rectTransform.DOShakeRotation(duration, vibrateStrength).SetEase(Ease.OutElastic).SetLoops(-1);

    }
    public void OnClick()
    {
        if (!clicked)
        {
            clicked = true;
            Audio_Manager.Instance.SFX_Shop();
            rotater.Kill();
            targetImage.rectTransform.DOScale(new Vector3(0.01f, 0.01f, 0.01f), 0.3f)
                .OnComplete(() =>
                {
                    targetImage.rectTransform.sizeDelta = new Vector2(643, 649);
                    int temp = r.Next(0, 1000);
                    int Value = 0;
                    Debug.Log(temp);
                    switch (temp)
                    {
                        case int n when (0 <= n && n <= 1): Value = 30; targetImage.sprite = sprites[4]; break;

                        case int n when (2 <= n && n <= 31): Value = 20; targetImage.sprite = sprites[3]; break;

                        case int n when (32 <= n && n <= 671): Value = 15; targetImage.sprite = sprites[3]; break;

                        case int n when (672 <= n && n <= 999): Value = 10; targetImage.sprite = sprites[3]; break;
                    }

                    StaminaManager.instance.StaminaUp(Value);
                    Fx_Manager.instance.GetItemFx(Value);
                    text.gameObject.SetActive(true);
                    text.text = "물고기 " + Value + "개 획득!";
                    Peresto.SetActive(false);
                // 애니메이션이 완료되면 스프라이트를 변경하고 이미지 확대 애니메이션 수행
                
                    targetImage.rectTransform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.5f);
                    
                    StartCoroutine(WaitAndClose());
                });
        }

    }
    IEnumerator WaitAndClose()
    {
        yield return new WaitForSeconds(3f);
        rotater = targetImage.rectTransform.DOShakeRotation(duration, vibrateStrength).SetEase(Ease.OutElastic).SetLoops(-1);
        targetImage.sprite = sprites[0];
        targetImage.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        clicked = false;
        targetImage.rectTransform.sizeDelta = new Vector2(420, 329);
        text.gameObject.SetActive(false);
        Peresto.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
    }
}
