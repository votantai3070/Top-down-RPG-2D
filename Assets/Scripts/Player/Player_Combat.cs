using UnityEngine;

public class Player_Combat : Entity_Combat
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public override Collider2D[] FindAttackTarget(Transform attackArea)
    {
        attackRadius = player.attackRadius;
        return base.FindAttackTarget(attackArea);
    }
}
