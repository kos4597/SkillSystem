using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class Actor : MonoBehaviour
{
    [NonSerialized]
    public ActorData ActorData = null;
    [SerializeField]
    private PlayerInput playerInput = null;

    private List<Skill> skillSet = new List<Skill>();
    public List<Skill> SkillSet => skillSet;

    private Vector3 targetPosition = Vector3.zero;
    private bool isMoving = false;

    private bool isMine = false;

    private bool isControllAble = true;
    public bool IsControllAble
    { // 상태이상 저장
        get
        {
            return isControllAble;
        }
        set 
        {
            Debug.Log($"상태이상 여부 : {isControllAble}");
            isControllAble = value;        
        }
    } 

    private void Awake()
    {
        isMine = gameObject.CompareTag("Player");

        CopyActorData(GoogleSheetManager.SO<GoogleSheetSO>().ActorDataList[0]);
        playerInput.enabled = isMine;

        InitSkillSet();
    }

    private void CopyActorData(ActorData actorData)
    {
        ActorData = new ActorData();

        ActorData.ActorId = actorData.ActorId;
        ActorData.ActorName = actorData.ActorName;
        ActorData.MoveSpeed = actorData.MoveSpeed;
        ActorData.HpValue = actorData.HpValue;
        ActorData.MpValue = actorData.MpValue;
        ActorData.SkillIds = actorData.SkillIds;
    }

    private void InitSkillSet()
    {
        foreach (var skillData in GoogleSheetManager.SO<GoogleSheetSO>().SkillDataList)
        {
            Skill skill = new Skill();
            skill.SetSkillData(skillData);

            for (int i = 0; i < skillData.EffectIds.Length; i++)
            {
                if (GoogleSheetManager.SO<GoogleSheetSO>().EffectDataList.Find(x => x.EffectId == skillData.EffectIds[i]) == null)
                    continue;

                Effect effect = (EffectType)GoogleSheetManager.SO<GoogleSheetSO>().EffectDataList.Find(x => x.EffectId == skillData.EffectIds[i]).EffectId switch
                {
                    EffectType.ManaEffect => new ManaEffect(),
                    EffectType.DamageEffect => new DamageEffect(),
                    EffectType.SpeedUpEffect => new SpeedUpEffect(),
                    EffectType.GrabEffect => new GrabEffect(),
                    EffectType.AirborneEffect => new AirborneEffect(),
                    EffectType.StunEffect => new StunEffect(),
                    _ => null
                };

                effect.SetEffectData(GoogleSheetManager.SO<GoogleSheetSO>().EffectDataList.Find(x => x.EffectId == skillData.EffectIds[i]));
                skill.AddSkillEffect(effect);
            }

            skillSet.Add(skill);
        }
    }

    void OnMove()
    {
        Debug.Log("OnMove");
        Ray ray = playerInput.camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            targetPosition = hit.point;
            isMoving = true;
        }
    }

    private void Update()
    {
        if (isMoving && IsControllAble)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, ActorData.MoveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }
}
