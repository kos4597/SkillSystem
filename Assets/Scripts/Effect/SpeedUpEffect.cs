using System.Collections;
using UnityEngine;

public class SpeedUpEffect : Effect
{
    public override bool Apply(Actor source, Actor target)
    {
        Debug.Log($"Apply {nameof(SpeedUpEffect)}");

        if (source == null)
            return false;

        if (source.ActorData == null)
            return false;

        source.ActorData.MoveSpeed *= EffectData.EffectValue;
        return true;
    }

    public override IEnumerator ApplyBehaviorEffect(Actor source, Actor target)
    {
        float elapsed = 0f;

        while (elapsed < EffectData.EffectDurationTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 1.0f;
            yield return null;
        }

        Debug.Log("RunAway Skill End");
        source.ActorData.MoveSpeed = GoogleSheetManager.SO<GoogleSheetSO>().ActorDataList[0].MoveSpeed; // ¿øº» µ¤±â
    }
}
