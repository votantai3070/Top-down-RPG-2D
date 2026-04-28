using UnityEngine;

public class Player_SkillManager : MonoBehaviour
{
    public Skill_AbsorbSoul absorbSoulManager { get; private set; }

    private void Awake()
    {
        absorbSoulManager = GetComponentInChildren<Skill_AbsorbSoul>();
    }

    private void Update()
    {
        absorbSoulManager.TryUseSkill();
    }
}
