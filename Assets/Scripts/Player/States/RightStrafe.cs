using UnityEngine;

public class RightStrafe : StrafeState
{
    public RightStrafe(
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
}