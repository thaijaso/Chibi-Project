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
            stateMachine.SetState(player.idle);
        }

        if (!player.PlayerInput.IsAiming && player.PlayerInput.IsMoving)
        {
            stateMachine.SetState(player.run);
        }

        if (player.PlayerInput.IsShooting)
        {
            stateMachine.SetState(player.shootHandgun);
        }

        if (player.PlayerInput.IsMoving && player.PlayerInput.IsAiming)
        {
            stateMachine.SetState(player.moveAim);
        }
    }
}
