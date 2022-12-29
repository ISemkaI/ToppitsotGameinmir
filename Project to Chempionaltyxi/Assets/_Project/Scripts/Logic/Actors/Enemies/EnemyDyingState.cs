using System;

public class EnemyDyingState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly IAnimatable _animatable;
    private readonly Action _enemyDied;

    public EnemyDyingState(IStateSwitcher stateSwitcher, IAnimatable animatable, Action enemyDied)
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
        _enemyDied?.Invoke();
        _animatable.DiedAnimationPlayedEvent?.RemoveListener(SubscribeOnDeathEnd);
    }

    private void SubscribeOnDeathEnd() 
        => _stateSwitcher.SwitchState<EnemyEmptyState>();

}