using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : MonoBehaviour, IState
{
    // State Machine
    PlayerStateMachine stateMachine;

    // Transitionable States
    IState playerFallState;


    // Declare Variables
    private Rigidbody2D rb;
    private Animator anim;

    public void EnterState()
    {
        stateMachine = GetComponent<PlayerStateMachine>();

        playerFallState = GetComponent<PlayerFallState>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        anim.SetTrigger("Jump_Trigger");
    }

    public void ExitState()
    {
    }

    public void ExecuteState()
    {
    }

    public void FixedExecuteState()
    {
        rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        stateMachine.TransitionState(playerFallState);
    }
}