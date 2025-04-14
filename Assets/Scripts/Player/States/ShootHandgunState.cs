using UnityEngine;

public class ShootHandgunState : PlayerState
{
    public ShootHandgunState(
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

        if (!animationManager.IsAnimationPlaying(animationName) && !player.PlayerInput.IsMoving)
        {
            stateMachine.SetState(player.idle);
        }

        if (!animationManager.IsAnimationPlaying(animationName) && player.PlayerInput.IsAiming)
        {
            stateMachine.SetState(player.aim);
        }

        if (!animationManager.IsAnimationPlaying(animationName) && player.PlayerInput.IsMoving)
        {
            stateMachine.SetState(player.run);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
