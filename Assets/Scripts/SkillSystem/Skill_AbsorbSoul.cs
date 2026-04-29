using UnityEngine;

public class Skill_AbsorbSoul : Skill_Base
{
    [Header("Absorb Soul Settings")]
    public float distanceToAbsorb = .5f;
    public float speedOfSoul = 5f;
    public float checkEnemyRadius = 3f;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void TryUseSkill()
    {
        if (!CanUseSkill())
            return;


        if (upgradeType == SkillUpgradeType.AbsorbSoulUpgrade)
        {
            distanceToAbsorb = 5f;
            speedOfSoul = 10f;

            SetSkillOnCooldown();
        }
    }

    public void AbsorbSoul(SkillObject_Soul soul)
    {
        if (Vector3.Distance(soul.transform.position, player.transform.position) > distanceToAbsorb)
            return;
    }
}
