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

    private void Update()
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
        if (health <= 0)
        {
            enemy.TryToDieState();
            dropSystem.SpawnDrop();
        }
    }


    private void OnDisable()
    {
        health = maxHealth;
    }
}
