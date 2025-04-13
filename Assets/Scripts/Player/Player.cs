using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerInput PlayerInput { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public AnimationManager AnimationManager { get; private set; }

    private PlayerStateMachine stateMachine;
    
    internal PlayerState idleState;
    internal PlayerState runState;
    internal PlayerState jumpState;
    internal PlayerState aimState;
    internal PlayerState shootState;

    // Use this for initialization
    void Start()
	{
        PlayerInput = GetComponent<PlayerInput>();
        if (PlayerInput == null) Debug.LogError("PlayerInput component is missing!");

        PlayerMovement = GetComponent<PlayerMovement>();
        if (PlayerMovement == null) Debug.LogError("PlayerMovement component is missing!");

        Animator animator = GetComponent<Animator>();
        if (animator == null) Debug.LogError("Animator component is missing!");
        
        AnimationManager = new AnimationManager(animator); 
        stateMachine = new PlayerStateMachine();

        // Initialize states
        idleState = new IdleState(this, stateMachine, AnimationManager, "Idle");
        runState = new RunState(this, stateMachine, AnimationManager, "Run");
        jumpState = new JumpState(this, stateMachine, AnimationManager, "Jump");
        aimState = new AimState(this, stateMachine, AnimationManager, "Aim");
        shootState = new ShootState(this, stateMachine, AnimationManager, "Shoot");

        // Set initial state
        stateMachine.SetState(idleState);
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
