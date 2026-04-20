using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public static ControlsManager instance { get; private set; }

    public PlayerControls inputActions;

    public Vector2 moveInput { get; private set; }

    private void Awake()
    {
        instance = this;

        inputActions = new PlayerControls();
    }

    private void Start()
    {
        AssignInputEvents();
    }

    private void AssignInputEvents()
    {
        // Move input
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;


    }

    public bool PressedAttack() => inputActions.Player.Attack.WasPressedThisFrame();

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
