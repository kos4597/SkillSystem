using System.Collections;
using UnityEngine;

public class GrabEffect : Effect
{
    public override bool Apply(Actor source, Actor target)
    {
        return true;
    }

    public override IEnumerator ApplyBehaviorEffect(Actor source, Actor target)
    {
        Debug.Log($"Apply {nameof(GrabEffect)}");

        Vector3 startPos = target.transform.position;
        Vector3 direction = (target.transform.position - source.transform.position).normalized;
        Vector3 endPos = source.transform.position + direction;
        endPos.y = target.transform.position.y; // 높이 유지

        float timer = 0f;
        target.IsControllAble = false;

        while (timer < EffectData.EffectDurationTime)
        {

            timer += Time.deltaTime;
            float t = timer / EffectData.EffectDurationTime;
            target.transform.position = Vector3.Lerp(startPos, endPos, t);

            yield return null;
        }

        target.transform.position = endPos;
        target.IsControllAble = true;
    }
}
