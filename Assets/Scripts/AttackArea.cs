using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private Collider2D collider;
    private Entity entity;
    private bool canHit;

    private void Awake()
    {
        entity = GetComponentInParent<Entity>();
    }

    private void OnValidate()
    {
        collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
        gameObject.name = transform.root.name + " - " + "AttackArea";
    }

    private void Update()
    {
        Vector2 direction = new Vector2(entity.xIdleAndAttack, entity.yIdleAndAttack).normalized;
        transform.position = entity.transform.position + (Vector3)(direction * entity.attackRange);

        if (entity.canAttack)
            collider.enabled = true;
        else
            collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (entity.canAttack)
        {
            foreach (Collider2D col in entity.entityCombat.FindAttackTarget(transform))
            {
                if (col.TryGetComponent(out IDamageable damageable) == false)
                    continue;

                canHit = damageable.TakeDamage(entity.attackDamage, entity.transform);

                Debug.Log("Hit " + col.gameObject.layer);
            }
        }
    }
}
