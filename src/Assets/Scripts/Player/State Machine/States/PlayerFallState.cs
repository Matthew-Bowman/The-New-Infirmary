using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : MonoBehaviour, IState
{
    [SerializeField] private float movSpeed = 2.5f;

    // State Machine
    PlayerStateMachine stateMachine;

    // Transitionable States
    IState playerIdleState;
    IState playerMoveState;


    // Declare Variables
    private Vector2 movVector;
    private Rigidbody2D rb;
    private float timer;
    private Animator anim;

    public void EnterState()
    {
        stateMachine = GetComponent<PlayerStateMachine>();

        playerIdleState = GetComponent<PlayerIdleState>();
        playerMoveState = GetComponent<PlayerMoveState>();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timer = 0;

        anim.SetTrigger("Fall_Trigger");
    }

    public void ExitState()
    {
    }

    public void ExecuteState()
    {
        // CAPTURE Inputs
        float horizontal = Input.GetAxisRaw("Horizontal");

        // PERFORM calculations
        movVector = new Vector2(horizontal * movSpeed, 0);

        anim.SetFloat("Horizontal", horizontal);

        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, -transform.up, 1.0f);

        // CHECK transition conditions
        if (timer >= 0.25f && raycastHit.collider != null && raycastHit.collider.CompareTag("Ground"))
        {
            if (horizontal != 0)
                stateMachine.TransitionState(playerMoveState);
            else
                stateMachine.TransitionState(playerIdleState);
        }

        timer += Time.deltaTime;
    }

    public void FixedExecuteState()
    {
        movVector.y = rb.velocity.y;
        rb.velocity = movVector;
    }
}