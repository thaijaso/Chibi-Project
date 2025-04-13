using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    private PlayerState currentState;

    public void SetState(PlayerState newState)
    {
        if (currentState == newState)
        {
            Debug.Log($"State {newState.GetType().Name} is already active.");
            return;
        }

        currentState?.Exit();
        currentState = newState;
        currentState.Enter();

        Debug.Log($"Transitioned to state: {newState.GetType().Name}");
    }

    public void LogicUpdate()
    {
        currentState?.LogicUpdate();
    }

    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
}
