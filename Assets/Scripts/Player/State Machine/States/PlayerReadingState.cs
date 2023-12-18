using UnityEngine;
using UnityEngine.Events;

public class PlayerReadingState : MonoBehaviour, IState
{
    // Declare Variables
    [SerializeField] private Canvas canvas;
    [SerializeField] private UnityEvent dialogueEvent;

    // State Machine
    PlayerStateMachine stateMachine;

    // Transitionable States
    IState playerIdleState;


    public void EnterState()
    {
        stateMachine = GetComponent<PlayerStateMachine>();

        playerIdleState = GetComponent<PlayerIdleState>();

        canvas.enabled = true;
    }

    public void ExitState()
    {
        canvas.enabled = false;
    }

    public void ExecuteState()
    {

    }

    public void FixedExecuteState()
    {

    }
}