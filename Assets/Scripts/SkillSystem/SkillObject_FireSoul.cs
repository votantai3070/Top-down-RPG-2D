using UnityEngine;

public class SkillObject_FireSoul : SkillObject_Base
{
    public FireSoul_CreateState createState { get; private set; }
    public FireSoul_IdleState idleState { get; private set; }
    public FireSould_ShootAntecipationState shootAntecipationState { get; private set; }
    public FireSoul_Shot shotState { get; private set; }

    [Header("Fire Soul Settings")]
    public float speed { get; private set; }
    private Skill_FireSoul fireSoulManager;
    public Transform target { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        createState = new(this, stateMachine, "Create");
        idleState = new(this, stateMachine, "Idle");
        shootAntecipationState = new(this, stateMachine, "ShootAntecipation");
        shotState = new(this, stateMachine, "Shot");
    }

    protected override void Start()
    {
        stateMachine.Initialize(createState);
    }

    public void SetupFireSoul(Skill_FireSoul fireSoulManager)
    {
        this.fireSoulManager = fireSoulManager;
        speed = fireSoulManager.speed;
        target = fireSoulManager.target;
    }
}
