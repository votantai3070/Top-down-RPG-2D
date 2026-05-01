using UnityEngine;

public interface IDamageable
{
    bool TakeDamage(bool isCrit, float damage, Transform damagedDealer);
}
