using UnityEngine;

public class AimState : PlayerState
{
    public AimState(
        Player player,
        PlayerStateMachine stateMachine,
        AnimationManager animationManager,
        string animationName
    ) : base(
        player, 
        stateMachine, 
        animationManager, 
        animationName
    ) {}

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!player.PlayerInput.IsAiming && !player.PlayerInput.IsMoving)
        {
            stateMachine.SetState(player.idleState);
        }

        if (!player.PlayerInput.IsAiming && player.PlayerInput.IsMoving)
        {
            stateMachine.SetState(player.runState);
        }
    }
}
