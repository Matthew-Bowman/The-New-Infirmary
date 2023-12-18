using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerIdleState : MonoBehaviour, IState
{
    [SerializeField] UnityEvent dialogueEvent;

    // State Machine
    PlayerStateMachine stateMachine;

    // Transitionable States
    IState playerMoveState;
    IState playerJumpState;

    private Animator anim;
    public void EnterState()
    {
        stateMachine = GetComponent<PlayerStateMachine>();

        playerMoveState = GetComponent<PlayerMoveState>();
        playerJumpState = GetComponent<PlayerJumpState>();

        anim = GetComponent<Animator>();

        anim.SetTrigger("Idle_Trigger");
    }

    public void ExitState()
    {
    }

    public void ExecuteState()
    {
        // CAPTURE Inputs
        float horizontal = Input.GetAxis("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);

        // CHECK for transition
        if (jump)
            stateMachine.TransitionState(playerJumpState);

        if (horizontal != 0)
            stateMachine.TransitionState(playerMoveState);

        if (Input.GetKeyDown(KeyCode.F))
            dialogueEvent.Invoke();

    }

    public void FixedExecuteState()
    {
    }
}
