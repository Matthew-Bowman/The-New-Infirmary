using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : MonoBehaviour, IState
{
    [SerializeField] private float movSpeed = 2.5f;

    // State Machine
    PlayerStateMachine stateMachine;

    // Transitionable States
    IState playerIdleState;
    IState playerJumpState;


    // Declare Variables
    private Vector2 movVector;
    private Rigidbody2D rb;
    private Animator anim;

    public void EnterState()
    {
        stateMachine = GetComponent<PlayerStateMachine>();

        playerIdleState = GetComponent<PlayerIdleState>();
        playerJumpState = GetComponent<PlayerJumpState>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        anim.SetTrigger("Move_Trigger");
    }

    public void ExitState()
    {
    }

    public void ExecuteState()
    {
        // CAPTURE Inputs
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);


        // PERFORM calculations
        movVector = new Vector2(horizontal * movSpeed, 0);

        anim.SetFloat("Horizontal", horizontal);

        // CHECK for transition
        if (jump)
            stateMachine.TransitionState(playerJumpState);

        if (horizontal == 0)
            stateMachine.TransitionState(playerIdleState);
    }

    public void FixedExecuteState()
    {
        movVector.y = rb.velocity.y;
        rb.velocity = movVector;
    }
}