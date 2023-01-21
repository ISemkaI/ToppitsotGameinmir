using System;

public class EnemyDyingState : IState
{
    private readonly EnemyStateMachine _stateSwitcher;
    private readonly IAnimatable _animatable;
    private readonly Action<EnemyStateMachine> _enemyDied;

    public EnemyDyingState(EnemyStateMachine stateSwitcher, IAnimatable animatable, Action<EnemyStateMachine> enemyDied)
    {
        _stateSwitcher = stateSwitcher;
        _animatable = animatable;
        _enemyDied = enemyDied;
    }

    public void Enter()
    {
        _animatable.PlayDeathAnimation();
        _animatable.DiedAnimationPlayedEvent?.AddListener(SubscribeOnDeathEnd);
    }

    public void Exit()
    {
        _enemyDied?.Invoke(_stateSwitcher);
        _animatable.DiedAnimationPlayedEvent?.RemoveListener(SubscribeOnDeathEnd);
    }

    private void SubscribeOnDeathEnd() 
        => _stateSwitcher.SwitchState<EnemyEmptyState>();

}