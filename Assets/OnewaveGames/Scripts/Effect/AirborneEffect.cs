using System.Collections;
using UnityEngine;

public class AirborneEffect : Effect
{
    public override bool Apply(Actor source, Actor target)
    {
        return true;
    }

    public override IEnumerator ApplyBehaviorEffect(Actor source, Actor target)
    {
        Debug.Log($"Apply {nameof(AirborneEffect)}");

        target.IsControllAble = false;

        float originY = target.transform.position.y;

        float timer = 0f;
        while (timer < (EffectData.EffectDurationTime / 2f))
        {
            target.transform.position += Vector3.up * 2f * Time.deltaTime;
            timer += Time.deltaTime;

            yield return null;
        }

        timer = 0f;

        while (timer < (EffectData.EffectDurationTime / 2f))
        {
            target.transform.position -= Vector3.up * 2f * Time.deltaTime;
            timer += Time.deltaTime;

            yield return null;
        }

        // ���� �� ���� ó��
        target.IsControllAble = true;

        // ���� �� ��ġ ����(���� ����)
        target.transform.position = new Vector3(target.transform.position.x, originY, target.transform.position.z);
    }
}
