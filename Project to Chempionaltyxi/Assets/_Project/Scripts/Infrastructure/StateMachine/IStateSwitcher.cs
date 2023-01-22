public interface IStateSwitcher
{
    void SwitchState<TState>() where TState : notnull, IState;
}