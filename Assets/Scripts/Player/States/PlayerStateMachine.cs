using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    private readonly List<PlayerState> activeStates = new();
    private readonly List<PlayerState> statesToAdd = new();
    private readonly List<PlayerState> statesToRemove = new();

    public void AddState(PlayerState state)
    {
        Debug.Log($"Queing state to add: {state.GetType().Name}");
        if (!activeStates.Contains(state) && !statesToAdd.Contains(state))
        {
            statesToAdd.Add(state);
        }
    }

    public void RemoveState(PlayerState state)
    {
        Debug.Log($"Queuing state to remove: {state.GetType().Name}");
        if (activeStates.Contains(state) && !statesToRemove.Contains(state))
        {
            statesToRemove.Add(state);
        }
    }

    public void ApplyStateChanges()
    {
        // Add queued states
        foreach (var state in statesToAdd)
        {
            Debug.Log($"Adding state: {state.GetType().Name}");
            activeStates.Add(state);
            state.Enter();
        }
        statesToAdd.Clear();

        foreach(var state in statesToRemove)
        {
            Debug.Log($"Removing state: {state.GetType().Name}");
            activeStates.Remove(state);
            state.Exit();
        }
        statesToRemove.Clear();
    }

    public void LogicUpdate()
    {
        foreach (var state in activeStates)
        {
            state.LogicUpdate();
        }
        ApplyStateChanges();
    }

    public void PhysicsUpdate()
    {
        foreach (var state in activeStates)
        {
            state.PhysicsUpdate();
        }
        ApplyStateChanges();
    }
}
