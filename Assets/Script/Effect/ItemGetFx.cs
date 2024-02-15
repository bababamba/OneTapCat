using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemGetFx : MonoBehaviour
{   /*
    public void Explosion(Vector2 from, Vector2 to, float explo_range)
    {
        transform.position = from;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(from + Random.insideUnitCircle * explo_range, 0.25f).SetEase(Ease.OutCubic));
        sequence.Append(transform.DOMove(to, 0.5f).SetEase(Ease.InCubic));
        sequence.AppendCallback(() => { gameObject.SetActive(false); });

    }
    */
    public void Explosion(Vector2 from, Vector2 to, float explo_range)
    {
        transform.position = from;

        // 랜덤한 회전 각도를 설정합니다.
        float randomRotation = Random.Range(0f, 360f);

        // DOTween.Sequence()를 사용하여 여러 동작을 연속적으로 실행합니다.
        Sequence sequence = DOTween.Sequence();

        // 랜덤한 회전 각도로 초기 회전을 설정합니다.
        sequence.Append(transform.DORotate(new Vector3(0, 0, randomRotation), 0.01f));

        // 위치 이동과 동시에 랜덤한 회전을 적용합니다.
        sequence.Join(transform.DOMove(from + Random.insideUnitCircle * explo_range, 0.25f).SetEase(Ease.OutCubic));

        // 목표 위치로 이동하면서 랜덤한 회전을 적용합니다.
        sequence.Append(transform.DOMove(to, 0.5f).SetEase(Ease.InCubic));
        sequence.Join(transform.DORotate(new Vector3(0, 0, randomRotation + 360f), 0.5f, RotateMode.FastBeyond360));

        // 이동 및 회전이 완료된 후 콜백 함수를 실행하여 게임 오브젝트를 비활성화합니다.
        sequence.AppendCallback(() => { gameObject.SetActive(false); });
    }
}