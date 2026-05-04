using System.Collections.Generic;
using UnityEngine;

public class Skill_SpinningSword : Skill_Base
{
    [Header("Spinning Sword")]
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private float orbitRadius = 1.5f;
    [SerializeField] private float orbitSpeed = 180f;
    [SerializeField] private float duration = 5f;
    [SerializeField] private int swordCount = 3;

    [SerializeField] private List<SkillObject_SpinningSword> activeSwords = new();

    protected override void Awake()
    {
        base.Awake();
    }

    public override void TryUseSkill()
    {
        target = FindClosestTarget();

        if (CanUseSkill() == false) return;

        if (activeSwords.Count > 0) return;

        if (Vector2.Distance(target.position, transform.root.position) < checkEnemyRadius)
        {
            if (upgradeType == SkillUpgradeType.SpinningSword)
            {
                Debug.Log("Spawn sword");
                SpawnSwords(swordCount);
                SetSkillOnCooldown();
            }
        }

    }

    private void SpawnSwords(float swordCount = 2)
    {
        float angleStep = 360f / swordCount;

        for (int i = 0; i < swordCount; i++)
        {
            float startAngle = angleStep * i;

            GameObject obj = ObjectPool.instance.Spawn(swordPrefab.name, transform.position, Quaternion.identity);
            SkillObject_SpinningSword sword = obj.GetComponent<SkillObject_SpinningSword>();
            sword.SetupSword(this, entity, orbitRadius, orbitSpeed, duration, startAngle);

            activeSwords.Add(sword);
        }
    }

    // Call from SkillObject when duration expires
    public void OnSwordExpired(SkillObject_SpinningSword sword)
    {
        activeSwords.Remove(sword);
    }
}