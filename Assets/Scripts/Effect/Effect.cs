using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    public EffectData EffectData { get; private set; }

    public abstract bool Apply(Actor source, Actor target);

    public virtual IEnumerator ApplyBehaviorEffect(Actor source, Actor target)
    {
        yield return null;
    }

    public virtual void SetEffectData(EffectData effectData)
    {
        this.EffectData = effectData;
    }
}
