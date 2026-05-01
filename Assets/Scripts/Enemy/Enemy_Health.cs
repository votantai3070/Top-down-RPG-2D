using UnityEngine;

public class Enemy_Health : Entity_Health
{
    private Enemy enemy;
    private DropSystem dropSystem;

    protected override void Awake()
    {
        base.Awake();

        enemy = GetComponent<Enemy>();
        dropSystem = GetComponent<DropSystem>();
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(999, enemy.player);
        }
    }

    public override bool TakeDamage(float damage, Transform damagedDealer)
    {
        enemy.TryToIdleState();

        return base.TakeDamage(damage, damagedDealer);
    }

    protected override void UnBloody()
    {
        if (currentHealth <= 0)
        {
            enemy.TryToDieState();
            dropSystem.SpawnDrop();
        }
    }


    private void OnDisable()
    {
        currentHealth = (int)entity.entityStats.GetMaxHealth();
    }
}
