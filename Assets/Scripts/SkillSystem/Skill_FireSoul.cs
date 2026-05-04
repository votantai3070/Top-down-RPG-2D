using UnityEngine;

public class Skill_FireSoul : Skill_Base
{
    [Header("Fire Soul Ball Config")]
    [SerializeField] private GameObject fireSoulGo;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void TryUseSkill()
    {
        target = FindClosestTarget();

        if (!CanUseSkill())
            return;

        if (Vector2.Distance(target.position, transform.root.position) < checkEnemyRadius)
        {
            if (upgradeType == SkillUpgradeType.FireSoul)
            {
                CreateFireSoul(Vector3.one * 3);
                SetSkillOnCooldown();
            }
            else if (upgradeType == SkillUpgradeType.FireSoulUpgrade)
            {
                CreateFireSoul(Vector3.one * 5);
                SetSkillOnCooldown();
            }
        }
    }

    // Create fire soul
    public void CreateFireSoul(Vector3 scale)
    {
        GameObject fireSoul = ObjectPool.instance.Spawn(fireSoulGo.name, transform.position, transform.rotation);
        fireSoul.transform.localScale = scale;
        fireSoul.GetComponent<SkillObject_FireSoul>().SetupFireSoul(this);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(targetCheck.position, checkEnemyRadius);
    }
}
