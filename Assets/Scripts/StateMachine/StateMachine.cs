using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState currentState;
    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null) currentState.Enter();
    }
    void Update()
    {
        if (currentState != null) currentState.LogicUpdate();
    }

    void LateUpdate()
    {
        if (currentState != null) currentState.PhysicsUpdate();
    }
    public void ChangeState(BaseState state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }
}
