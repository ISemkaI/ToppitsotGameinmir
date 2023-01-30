using System;
using UnityEngine;

public class EnemyDyingState : IState
{
    private readonly EnemyStateMachine _stateSwitcher;
    private readonly Transform _enemy;
    private readonly IAnimatable _animatable;

    public Action<EnemyStateMachine> EnemyDied;

    public EnemyDyingState(EnemyStateMachine stateSwitcher, Transform enemy, IAnimatable animatable)
    {
        _stateSwitcher = stateSwitcher;
        _enemy = enemy;
        _animatable = animatable;
    }

    public void Enter()
    {
        _animatable.SubscribeDeathEndAnimation(SubscribeOnDeathEnd);
        _animatable.PlayDeathAnimation();
    }

    public void Exit()
    {
        EnemyDied?.Invoke(_stateSwitcher);
        _animatable.UnSubscribeDeathEndAnimation(SubscribeOnDeathEnd);

        GameObject.Destroy(_enemy.gameObject);
    }

    private void SubscribeOnDeathEnd()
    {
        _stateSwitcher.SwitchState<EnemyEmptyState>();
    }
}