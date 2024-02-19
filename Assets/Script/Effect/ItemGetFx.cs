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

        // ������ ȸ�� ������ �����մϴ�.
        float randomRotation = Random.Range(0f, 360f);

        // DOTween.Sequence()�� ����Ͽ� ���� ������ ���������� �����մϴ�.
        Sequence sequence = DOTween.Sequence();

        // ������ ȸ�� ������ �ʱ� ȸ���� �����մϴ�.
        sequence.Append(transform.DORotate(new Vector3(0, 0, randomRotation), 0.01f));

        // ��ġ �̵��� ���ÿ� ������ ȸ���� �����մϴ�.
        sequence.Join(transform.DOMove(from + Random.insideUnitCircle * explo_range, 0.25f).SetEase(Ease.OutCubic));

        // ��ǥ ��ġ�� �̵��ϸ鼭 ������ ȸ���� �����մϴ�.
        sequence.Append(transform.DOMove(to, 0.5f).SetEase(Ease.InCubic));
        sequence.Join(transform.DORotate(new Vector3(0, 0, randomRotation + 360f), 0.5f, RotateMode.FastBeyond360));

        // �̵� �� ȸ���� �Ϸ�� �� �ݹ� �Լ��� �����Ͽ� ���� ������Ʈ�� ��Ȱ��ȭ�մϴ�.
        sequence.AppendCallback(() => { gameObject.SetActive(false); });
    }
}