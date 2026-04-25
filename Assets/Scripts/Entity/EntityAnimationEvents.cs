using UnityEngine;

public class EntityAnimationEvents : MonoBehaviour
{
    private Entity entity;

    protected virtual void Awake()
    {
        entity = GetComponentInParent<Entity>();
    }

    protected virtual void TriggerEvent() => entity.canTrigger = true;

    private void AttackTrigger()
    {
        entity.entityCombat.ResetHitList();
        entity.entityCombat.Attack(entity);
    }
}