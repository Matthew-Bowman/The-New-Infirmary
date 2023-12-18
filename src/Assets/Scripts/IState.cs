public interface IState
{
    public void EnterState();
    public void ExitState();
    public void ExecuteState();
    public void FixedExecuteState();
}