using UnityEngine;

public class Entity_Health : MonoBehaviour, IDamageable
{
    protected Entity entity;

    [Space]
    [SerializeField] protected int currentHealth;

    protected virtual void Awake()
    {
        entity = GetComponent<Entity>();
    }

    protected virtual void Start()
    {
        currentHealth = (int)entity.entityStats.GetMaxHealth();
    }

    protected virtual void Update()
    {
    }

    public virtual bool TakeDamage(float damage, Transform damagedDealer)
    {
        if (currentHealth <= 0)
            return false;

        TakeKnockback(damagedDealer, damage);
        currentHealth -= (int)damage;

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
