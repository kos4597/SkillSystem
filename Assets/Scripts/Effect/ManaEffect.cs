using System.Collections;
using UnityEngine;

public class ManaEffect : Effect
{
    public override bool Apply(Actor source, Actor target)
    {
        if (source == null)
            return false;

        Debug.Log($"Apply {nameof(ManaEffect)}");

        if (source.ActorData.MpValue < EffectData.EffectValue)
        {
            Debug.Log("Not Enough MP");
            return false;
        }

        source.ActorData.MpValue -= (int)EffectData.EffectValue;
        return true;
    }
    public override IEnumerator ApplyBehaviorEffect(Actor source, Actor target)
    {
        return base.ApplyBehaviorEffect(source, target);
    }
}
