using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    IState currentState;
    // Start is called before the first frame update
    void Start()
    {
        IState idleState = gameObject.GetComponent<PlayerIdleState>();

        this.InitialiseState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.ExecuteState();
    }

    private void FixedUpdate()
    {
        currentState.FixedExecuteState();
    }

    public void InitialiseState(IState state)
    {
        currentState = state;
        currentState.EnterState();
    }

    public void TransitionState(IState state)
    {
        currentState.ExitState();
        this.InitialiseState(state);
    }
}
