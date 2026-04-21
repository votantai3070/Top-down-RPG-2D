using UnityEngine;

public class EntityAnimationEvents : MonoBehaviour
{
    private Entity entity;

    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
    }

    private void TriggerEvent() => entity.canTrigger = true;

    private void AttackTrigger() => entity.canAttack = true;
}
