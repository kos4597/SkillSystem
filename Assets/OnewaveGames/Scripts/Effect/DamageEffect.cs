using System.Collections;
using UnityEngine;

public class DamageEffect : Effect
{
    public override bool Apply(Actor source, Actor target)
    {
        Debug.Log($"Apply {nameof(DamageEffect)}");

        source.ActorData.HpValue -= (int)EffectData.EffectValue;

        if(source.ActorData.HpValue < 0)        
            Debug.Log("DeadCallback");
        
        return true;
    }
    public override IEnumerator ApplyBehaviorEffect(Actor source, Actor target)
    {
        return base.ApplyBehaviorEffect(source, target);
    }
}
