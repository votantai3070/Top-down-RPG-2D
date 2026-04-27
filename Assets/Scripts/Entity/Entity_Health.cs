using UnityEngine;

public class Entity_Health : MonoBehaviour, IDamageable
{
    private Entity entity;
    public int health;
    protected int maxHealth = 100;

    protected virtual void Awake()
    {
        entity = GetComponent<Entity>();
    }

    private void Update()
    {
    }

    public virtual bool TakeDamage(float damage, Transform damagedDealer)
    {
        if (health <= 0)
            return false;

        TakeKnockback(damagedDealer, damage);
        health -= (int)damage;

        UnBloody();

        return true;
    }

    protected virtual void UnBloody()
    {

    }

    public virtual void Die()
    {
        ObjectPool.instance.Despawn(gameObject);
    }

    protected virtual void TakeKnockback(Transform damagedDealer, float finalDamage)
    {
        //float averangeDamage = finalDamage / entityStats.GetMaxHealth();
        float averangeDamage = finalDamage / 100f;

        entity?.KnockBack(damagedDealer, averangeDamage);
    }
}
