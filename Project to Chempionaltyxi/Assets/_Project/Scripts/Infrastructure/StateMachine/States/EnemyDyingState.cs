using System;
using UnityEngine;

public class EnemyDyingState : IState
{
    private readonly EnemyStateMachine _stateSwitcher;
    private readonly Transform _enemy;
    private readonly IAnimatable _animatable;
    private readonly Action<EnemyStateMachine> _enemyDied;

    public EnemyDyingState(EnemyStateMachine stateSwitcher, Transform enemy, IAnimatable animatable, Action<EnemyStateMachine> enemyDied)
    {
        _stateSwitcher = stateSwitcher;
        _enemy = enemy;
        _animatable = animatable;
        _enemyDied = enemyDied;
    }

    public void Enter()
    {
        _animatable.PlayDeathAnimation();
        _animatable.DiedAnimationPlayedEvent?.AddListener(SubscribeOnDeathEnd);

        Debug.Log("Enter dying state");
    }

    public void Exit()
    {
        Debug.Log("death exit");

        _enemyDied?.Invoke(_stateSwitcher);
        _animatable.DiedAnimationPlayedEvent?.RemoveListener(SubscribeOnDeathEnd);

        GameObject.Destroy(_enemy.gameObject);
    }

    private void SubscribeOnDeathEnd()
    {
        Debug.Log("Switched to death end");
        _stateSwitcher.SwitchState<EnemyEmptyState>();
    }
}