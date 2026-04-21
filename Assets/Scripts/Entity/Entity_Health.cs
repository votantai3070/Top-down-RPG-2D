using UnityEngine;

public class Entity_Health : MonoBehaviour, IDamageable
{
    private Entity entity;

    private void Awake()
    {
        entity = GetComponent<Entity>();
    }

    public bool TakeDamage(float damage, Transform damagedDealer)
    {
        TakeKnockback(damagedDealer, damage);

        return true;
    }

    private void TakeKnockback(Transform damagedDealer, float finalDamage)
    {
        //float averangeDamage = finalDamage / entityStats.GetMaxHealth();
        float averangeDamage = finalDamage / 100f;

        entity?.KnockBack(damagedDealer, averangeDamage);
    }
}
