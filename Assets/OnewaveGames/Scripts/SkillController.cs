using System.Collections;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    private Actor player = null;
    private Actor target = null;
    private Coroutine skillCor = null;
    
    private int segments = 100;

    private SkillIndex PreparedSkillIndex = SkillIndex.None;

    private void Start()
    {
        player = InGameManager.Instance.Player;
        target = InGameManager.Instance.Enemy;
        InitSkillRange();
        PrepareSkill(SkillIndex.None);
    }

    // 고민 : 입력받은 키값으로 분기를 치는게 나을지..
    void OnSkill01()
    {
        if (player.SkillSet[(int)SkillIndex.Skill01].SkillData.IsImmediately == false)
        {
            PrepareSkill(SkillIndex.Skill01);
            DrawSkillRange(player.SkillSet[(int)SkillIndex.Skill01].SkillData);
            SwitchSkillRange();
        }

        else
        {
            ApplySkill(player.SkillSet[(int)SkillIndex.Skill01],target);
        }
    }

    void OnSkill02()
    {
        if(player.SkillSet[(int)SkillIndex.Skill02].SkillData.IsImmediately == false)
        {
            PrepareSkill(SkillIndex.Skill02);
            DrawSkillRange(player.SkillSet[(int)SkillIndex.Skill02].SkillData);
            SwitchSkillRange();
        }

        else
        {
            ApplySkill(player.SkillSet[(int)SkillIndex.Skill02], target);
        }
    }

    void OnSkill03()
    {
        if (player.SkillSet[(int)SkillIndex.Skill03].SkillData.IsImmediately == false)
        {
            PrepareSkill(SkillIndex.Skill03);
            DrawSkillRange(player.SkillSet[(int)SkillIndex.Skill03].SkillData);
            SwitchSkillRange();
        }

        else
        {
            ApplySkill(player.SkillSet[(int)SkillIndex.Skill03], target);
        }
    }

    void OnSkill04()
    {
        if (player.SkillSet[(int)SkillIndex.Skill04].SkillData.IsImmediately == false)
        {
            PrepareSkill(SkillIndex.Skill04);
            DrawSkillRange(player.SkillSet[(int)SkillIndex.Skill04].SkillData);
            SwitchSkillRange();
        }

        else
        {
            ApplySkill(player.SkillSet[(int)SkillIndex.Skill04], target);
        }
    }

    void OnApplySkill()
    {
        if(lineRenderer.enabled && PreparedSkillIndex > SkillIndex.None)
        {
            SwitchSkillRange();
            ApplySkill(player.SkillSet[(int)PreparedSkillIndex], target);
        }
        else
        {
            Debug.Log("PreparedSkill is None");
        }
    }

    private void InitSkillRange()
    {
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        lineRenderer.enabled = false;
    }

    private void PrepareSkill(SkillIndex index)
    {
        PreparedSkillIndex = index;
    }

    private void SwitchSkillRange()
    {
        lineRenderer.enabled = !lineRenderer.enabled;
    }

    private void DrawSkillRange(SkillData data)
    {
        float angle = 0f;
        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Cos(angle) * data.SkillRange;
            float z = Mathf.Sin(angle) * data.SkillRange;
            lineRenderer.SetPosition(i, new Vector3(x, 0.01f, z));
            angle += 2 * Mathf.PI / segments;
        }
    }

    private void ApplySkill(Skill skill, Actor target)
    {
        if (player.SkillSet == null)
            return;

        if (player.SkillSet.Count <= 0)
            return;

        if(target == null || target.Equals(null)) 
            return;

        if (skill.ApplySkill(player, target) == false)
        {
            Debug.Log($"{nameof(ApplySkill)} Failed");
        }

        else
        {
            skill.PlaySkillSound();

            if (skillCor != null)
            {
                StopCoroutine(skillCor);
                skillCor = null;
            }

            skillCor = StartCoroutine(skill.ApplySkillBehavior(player, target));
        }
    }
}
