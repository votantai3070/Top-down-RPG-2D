using UnityEngine;

public class Player_Health : Entity_Health
{
    private Player player;

    protected override void Awake()
    {
        base.Awake();

        player = GetComponent<Player>();
    }

    public override bool TakeDamage(float damage, Transform damagedDealer)
    {
        return base.TakeDamage(damage, damagedDealer);
    }
}
