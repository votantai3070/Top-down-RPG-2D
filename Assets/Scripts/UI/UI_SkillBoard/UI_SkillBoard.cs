using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_SkillBoard : MonoBehaviour
{

    [SerializeField] private Skill_ListDataSO skillsData;
    [SerializeField] private UI_SkillCard[] cards;

    [Header("Card restrictions")]
    [SerializeField] private int maxRarityAmount = 1200;
    [SerializeField] private int maxSkillToRoll = 3;

    private void Awake()
    {
        cards = GetComponentsInChildren<UI_SkillCard>();
    }

    private void Start()
    {
        GetSkillsRollRandom();
    }

    public void GetSkillsRollRandom()
    {
        //if (skillsData == null && skillsData.skillList == null)
        //    return;

        List<Skill_DataSO> skillsToRoll = RollSkills();
        int amountSkills = Mathf.Min(skillsToRoll.Count, maxSkillToRoll);

        Debug.Log("Amount Skills: " + amountSkills);

        for (int i = 0; i < amountSkills; i++)
        {
            string colorText = GetColorByRarity(skillsToRoll[i].skillRarity);
            cards[i].SetCardInfo(skillsToRoll[i], colorText);
        }
    }

    public List<Skill_DataSO> RollSkills()
    {
        List<Skill_DataSO> possibleSkills = new();
        List<Skill_DataSO> finalSkills = new();
        List<Skill_DataSO> availiableSkills = InitializeSkills();

        float maxRarityAmount = this.maxRarityAmount;

        // Step 1: Roll each item based on rarity and max drop chance
        foreach (var skill in availiableSkills)
        {
            float rollChance = skill.GetSkillRollChance();

            if (Random.Range(0, 100) < rollChance)
                possibleSkills.Add(skill);
        }

        //Step 2: Sort by rarity (hightest to lowest)
        possibleSkills = possibleSkills.OrderByDescending(skill => skill.skillRarity).ToList();

        //Step 3: Add items to final drop list until rarity limit in entity is reached
        foreach (var skill in possibleSkills)
        {
            if (maxRarityAmount > skill.skillRarity)
            {
                finalSkills.Add(skill);
                maxRarityAmount -= skill.skillRarity;
            }
        }

        return finalSkills;
    }

    private List<Skill_DataSO> InitializeSkills()
    {
        List<Skill_DataSO> availiableSkills = new(skillsData.skillList.Length);

        foreach (var skill in skillsData.skillList)
        {
            if (skill.canUpgrade == false)
                availiableSkills.Add(skill);
        }

        return availiableSkills;
    }

    private string GetColorByRarity(int rarity)
    {
        if (rarity <= 150) return "#FFFFFF"; // Common
        if (rarity <= 400) return "#437A22"; // Uncommon
        if (rarity <= 600) return "#006494"; // Rare
        if (rarity <= 800) return "#7A39BB"; // Epic
        return "#FFD700";                    // Legendary
    }
}
