using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public List<Effect> EffectList { get; private set; }

    public SkillData SkillData { get; private set; }

    public bool ApplySkill(Actor source, Actor target)
    {
        foreach (var effect in EffectList)
        {
            if (effect == null)
                continue;

            if (effect.EffectData == null)
                continue;

            if (effect.EffectData.IsBehavior)
                continue;

            else if (effect.Apply(source, target) == false)
                return false;
        }

        return true;
    }

    public IEnumerator ApplySkillBehavior(Actor source, Actor target)
    {
        if (IsTargetInRange(source, target) == false)
        {
            Debug.Log("Target is Out of SkillRange");
            yield break;
        }

        foreach (var effect in EffectList)
        {
            if (effect == null)
                continue;

            if (effect.EffectData == null)
                continue;

            if (effect.EffectData.IsBehavior == false && effect.EffectData.IsBuff == false)
                continue;

            yield return effect.ApplyBehaviorEffect(source, target);
        }
    }

    public void SetSkillData(SkillData skillData)
    {
        this.SkillData = skillData;
    }

    public void SetSkillEffect(List<Effect> effectList)
    {
        this.EffectList = effectList;
    }

    public void AddSkillEffect(Effect effect)
    {
        if(EffectList == null)
            EffectList = new List<Effect>();

        this.EffectList.Add(effect);
    }

    public bool IsTargetInRange(Actor player, Actor target)
    {
        if (SkillData.IsImmediately)
            return true;

        float distance = Vector3.Distance(player.transform.position, target.transform.position);
        return distance <= SkillData.SkillRange;
    }

    public void PlaySkillSound()
    {
        if (SkillData == null)
            return;

        if (string.IsNullOrEmpty(SkillData.SkillSound))
            return;

        SoundManager.Instance.PlaySFX(SkillData.SkillSound);
    }
}
public enum EffectType
{
    ManaEffect = 1001,
    DamageEffect = 1002,
    SpeedUpEffect = 1003,
    GrabEffect = 1004,
    AirborneEffect = 1005,
    StunEffect = 1006,
}

public enum SkillIndex
{
    None = -1,
    Skill01 = 0,
    Skill02,
    Skill03,
    Skill04,
}


