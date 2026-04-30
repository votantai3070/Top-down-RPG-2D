using UnityEngine;

public class Skill_FireSoul : Skill_Base
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void TryUseSkill()
    {
        target = FindClosestTarget();

        if (!CanUseSkill())
            return;

        if (Vector2.Distance(target.position, transform.position) < checkEnemyRadius)
            if (upgradeType == SkillUpgradeType.FireSoul)
            {
                CreateFireSoul();
                SetSkillOnCooldown();
            }
    }

    // Create fire soul
    public void CreateFireSoul()
    {
        GameObject fireSoul = ObjectPool.instance.Spawn("FireSoul", transform.position, transform.rotation);
        fireSoul.GetComponent<SkillObject_FireSoul>().SetupFireSoul(this);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(targetCheck.position, checkEnemyRadius);
    }
}
