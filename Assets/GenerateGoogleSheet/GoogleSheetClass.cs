using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>You must approach through `GoogleSheetManager.SO<GoogleSheetSO>()`</summary>
public class GoogleSheetSO : ScriptableObject
{
	public List<SkillData> SkillDataList;
	public List<ActorData> ActorDataList;
	public List<EffectData> EffectDataList;
}

[Serializable]
public class SkillData
{
	public int SkillId;
	public string SkillName;
	public int[] EffectIds;
	public int SkillRange;
	public bool IsImmediately;
	public string SkillSound;
}

[Serializable]
public class ActorData
{
	public int ActorId;
	public string ActorName;
	public float MoveSpeed;
	public int HpValue;
	public int MpValue;
	public int[] SkillIds;
}

[Serializable]
public class EffectData
{
	public int EffectId;
	public string EffectDesc;
	public int EffectValue;
	public float EffectDurationTime;
	public bool IsBehavior;
	public bool IsBuff;
}

