public class Player_AnimationEvents : EntityAnimationEvents
{
    private Player player;

    protected override void Awake()
    {
        if (GetComponents<EntityAnimationEvents>().Length > 1)
        {
            Destroy(this);
            return;
        }

        base.Awake();

        player = GetComponentInParent<Player>();
    }



    protected override void TriggerEvent()
    {
        base.TriggerEvent();
    }
}
