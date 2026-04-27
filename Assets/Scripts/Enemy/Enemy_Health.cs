using UnityEngine;

public class Enemy_Health : Entity_Health
{
    private Enemy enemy;

    protected override void Awake()
    {
        base.Awake();

        enemy = GetComponent<Enemy>();
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
        }
    }


    private void OnDisable()
    {
        health = maxHealth;
    }
}
