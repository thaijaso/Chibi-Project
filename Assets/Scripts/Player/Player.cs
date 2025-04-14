using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInput PlayerInput { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public AnimationManager AnimationManager { get; private set; }

    private PlayerStateMachine stateMachine;
    
    internal PlayerState idle;
    internal PlayerState run;
    internal PlayerState jump;
    internal PlayerState aim;
    internal PlayerState shootHandgun;
    internal PlayerState moveAim;

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
        idle = new IdleState(this, stateMachine, AnimationManager, "Idle");
        run = new RunState(this, stateMachine, AnimationManager, "Run");
        jump = new JumpState(this, stateMachine, AnimationManager, "Jump");
        aim = new AimState(this, stateMachine, AnimationManager, "Aim");
        shootHandgun = new ShootHandgunState(this, stateMachine, AnimationManager, "Shoot Revolver");
        moveAim = new MoveAimState(this, stateMachine, AnimationManager, "Walk Aim");


        // Set initial state
        stateMachine.SetState(idle);
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
