using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill - ", menuName = "RPG Setup/Skill/Skill Data")]
public class Skill_DataSO : ScriptableObject
{
    public string saveId;

    [Header("Skill Description")]
    public string displayName;
    [TextArea(3, 10)]
    public string description;
    public Sprite icon;

    [Header("Upgrade")]
    public SkillType skillType;
    public UpgradeData upgradeData;

    [System.NonSerialized]
    public bool canUpgrade;
    [Range(0, 100)]
    public float upgradeBoostChance = 30f;

    [Header("Skill Roll")]
    [Range(0, 1000)]
    public int skillRarity = 100;
    [Range(0, 100)]
    public float skillRollChance;
    [Range(0, 100)]
    public float maxSkillRollChance = 65f;

    [System.Serializable]
    public class UpgradeData
    {
        public SkillUpgradeType upgradeType;
        public float cooldown;
        public float distanceToAttack;
        public float attackRadius;
        public float speed;
        //public DamageScaleData damageScale;
    }

    private void OnValidate()
    {
        skillRollChance = GetSkillRollChance();

#if UNITY_EDITOR
        string path = AssetDatabase.GetAssetPath(this);
        saveId = AssetDatabase.AssetPathToGUID(path);
#endif  
    }

    public void SetUpgrade(bool upgrade) => canUpgrade = upgrade;

    public float GetSkillRollChance()
    {
        float maxRarity = 1000;
        float chance = (maxRarity - skillRarity + 1) / maxRarity * 100;

        if (canUpgrade)
            chance += upgradeBoostChance;

        return Mathf.Min(chance, maxSkillRollChance);
    }
}
