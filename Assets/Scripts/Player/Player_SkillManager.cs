using UnityEngine;

public class Player_SkillManager : MonoBehaviour
{
    public Skill_AbsorbSoul absorbSoul { get; private set; }
    public Skill_FireSoul fireSoul { get; private set; }

    public Skill_Base[] allSkills { get; private set; }


    private void Awake()
    {
        absorbSoul = GetComponentInChildren<Skill_AbsorbSoul>();
        fireSoul = GetComponentInChildren<Skill_FireSoul>();

        allSkills = GetComponentsInChildren<Skill_Base>();
    }

    private void Update()
    {
        foreach (var spell in allSkills)
        {
            if (spell.upgradeType != SkillUpgradeType.None)
                spell.TryUseSkill();
        }
    }

    public void ReduceAllSkillCooldownBy(float amount)
    {
        foreach (var skill in allSkills)
            skill.ReduceCooldownBy(amount);
    }

    public Skill_Base GetSkillByType(SkillType type)
    {
        switch (type)
        {
            case SkillType.AbsorbSoul: return absorbSoul;
            case SkillType.FireSoul: return fireSoul;

            default:
                Debug.Log($"Skill type {type} is not implemented yet.");
                return null;
        }
    }

}
