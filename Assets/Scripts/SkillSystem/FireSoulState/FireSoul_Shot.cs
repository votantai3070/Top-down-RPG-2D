using UnityEngine;

public class FireSoul_Shot : FireSoul_State
{
    public FireSoul_Shot(SkillObject_FireSoul spellSkill, StateMachine<SpellState> stateMachine, string animBoolName) : base(spellSkill, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (spellSkill.target == null)
            return;

        spellSkill.transform.position = Vector3.MoveTowards(spellSkill.transform.position, spellSkill.target.position, spellSkill.speed * Time.deltaTime);

        if (Vector2.Distance(spellSkill.transform.position, spellSkill.target.position) < .2f)
            ObjectPool.instance.Despawn(spellSkill.gameObject);
    }
}
