using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerInput PlayerInput { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public Animator Animator { get; private set; }

    private PlayerStateMachine stateMachine;
    internal PlayerState moveState;
    internal PlayerState idleState;
    internal PlayerState jumpState;

    // Use this for initialization
    void Start()
	{
        PlayerInput = GetComponent<PlayerInput>();
        if (PlayerInput == null) Debug.LogError("PlayerInput component is missing!");

        PlayerMovement = GetComponent<PlayerMovement>();
        if (PlayerMovement == null) Debug.LogError("PlayerMovement component is missing!");

        Animator = GetComponent<Animator>();
        if (Animator == null) Debug.LogError("Animator component is missing!");

        stateMachine = new PlayerStateMachine();

        // Initialize states
        idleState = new IdleState(this, stateMachine, Animator, "Idle");
        moveState = new MoveState(this, stateMachine, Animator, "Move");
        jumpState = new JumpState(this, stateMachine, Animator, "Jump");

        // Set initial state
        stateMachine.AddState(idleState);
    }

	// Update is called once per frame
	void Update()
	{
        stateMachine.LogicUpdate();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
}
