using UnityEngine;

public class Entity : MonoBehaviour
{
    public StateMachine stateMachine { get; private set; }
    public ControlsManager controls { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }

    protected virtual void Awake()
    {
        stateMachine = new StateMachine();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        controls = ControlsManager.instance;

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 0f;
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        stateMachine.currentState.Update();
    }

    public void SetVelocity(float x, float y)
    {
        rb.linearVelocity = new(x, y);
    }
}
