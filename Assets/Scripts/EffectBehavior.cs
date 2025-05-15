using UnityEngine;

public class EffectBehavior : MonoBehaviour
{
    private void EffectApply(Effect effect, Actor source, Actor target)
    {
        if(effect.EffectData.IsBehavior)
        {

        }
        else
        {
            effect.Apply(source, target);
        }
    }

}
