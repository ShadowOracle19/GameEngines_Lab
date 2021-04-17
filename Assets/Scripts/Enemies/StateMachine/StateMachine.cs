using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState { get; private set; }

    protected Dictionary<ZombieStateType, State> states;
    private bool Running;

    private void Awake()
    {
        states = new Dictionary<ZombieStateType, State>();
    }

    public void Initialize(ZombieStateType startingState)
    {
        if(states.ContainsKey(startingState))
        {
            ChangeState(startingState);
        }
        else if(states.ContainsKey(ZombieStateType.Idle))
        {
            ChangeState(ZombieStateType.Idle);
        }
    }

    public void AddState(ZombieStateType stateName, State state)
    {
        if (states.ContainsKey(stateName)) return;

        states.Add(stateName, state);
    }

    public void RemoveState(ZombieStateType stateName)
    {
        if (!states.ContainsKey(stateName)) return;
        states.Remove(stateName);
    }

    public void ChangeState(ZombieStateType nextState)
    {
        if(Running)
        {
            StopRunningState();
        }

        if (!states.ContainsKey(nextState)) return;

        currentState = states[nextState];
        currentState.Start();

        if(currentState.UpdateInterval > 0)
        {
            InvokeRepeating(nameof(IntervalUpdate), 0.0f, currentState.UpdateInterval);
        }

        Running = true;
    }

    private void StopRunningState()
    {
        Running = false;
        currentState.Exit();
        CancelInvoke(nameof(IntervalUpdate));
    }

    private void IntervalUpdate()
    {
        if(Running)
        {
            currentState.IntervalUpdate();
        }
    }

    private void Update()
    {
        if(Running)
        {
            currentState.Update();
        }
    }

    private void FixedUpdate()
    {
        if (Running)
        {
            currentState.FixedUpdate();
        }
    }
}


