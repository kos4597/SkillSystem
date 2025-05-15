using System.Collections;
using UnityEngine;

public class StunEffect : Effect
{
    public override bool Apply(Actor source, Actor target)
    {
        return true;
    }

    public override IEnumerator ApplyBehaviorEffect(Actor source, Actor target)
    {
        Debug.Log($"Apply {nameof(StunEffect)}");

        target.IsControllAble = false;

        float timer = 0f;
        while (timer < EffectData.EffectDurationTime)
        {
            timer += Time.deltaTime;

            yield return null;
        }

        target.IsControllAble = true;
    }
}
