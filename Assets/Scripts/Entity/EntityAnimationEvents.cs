using UnityEngine;

public class EntityAnimationEvents : MonoBehaviour
{
    private Entity entity;

    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
    }

    private void AttackOnTrigger() => entity.canTriggerAttack = true;
}
