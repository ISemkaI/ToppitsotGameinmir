using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : IStateSwitcher
{
    private readonly ICoroutineRunner _coroutineRunner;

    private readonly Transform _enemy;
    private readonly Transform _player;

    private readonly PhysicsEventAdapter _physicsEventAdapter;
    private readonly NavMeshAgent _navMeshAgent;

    private readonly Healthable _healthable;
    private readonly IAnimatable _animatable;
    private readonly IShootable _shootable;

    public event Action<EnemyStateMachine> EnemyDiedEvent;

    #region STATE_MACHINE
    private readonly List<IState> _enemyStates;
    private IState _currentState;
    #endregion

    public EnemyStateMachine(Healthable healthable, IAnimatable animatable, IShootable shootable, 
        ICoroutineRunner coroutineRunner, Transform enemy, Transform player, PhysicsEventAdapter physicsEventAdapter, 
        NavMeshAgent navMeshAgent)
    {
        _healthable = healthable;
        _animatable = animatable;
        _shootable = shootable;

        _coroutineRunner = coroutineRunner;
        _enemy = enemy;
        _player = player;

        _physicsEventAdapter = physicsEventAdapter;
        _navMeshAgent = navMeshAgent;

        _enemyStates = new List<IState>
        {
            new EnemyMovementState(this, enemy, player, navMeshAgent, physicsEventAdapter),
            new EnemyShootingState(_shootable, coroutineRunner, player),
            new EnemyDyingState(this, _animatable, EnemyDiedEvent),
            new EnemyEmptyState(enemy),
        };

        SubscribeOnDeath();

        SwitchState<EnemyMovementState>();
    }

    // Отписываемся от событий
    ~EnemyStateMachine()
    {
        UnSubscribeOnDeath();
    }

    // Выходим из прежнего состояния, входим в новое.
    // Сложный шаблонный синтаксис
    public void SwitchState<TState>() where TState : notnull, IState
    {
        _currentState?.Exit();
        _currentState = _enemyStates.FirstOrDefault(x => x is TState);
        _currentState.Enter();
    }

    private void SubscribeOnDeath() 
        => _healthable.DiedEvent?.AddListener(SubscriptionOnDeath);

    private void SubscriptionOnDeath() 
        => SwitchState<EnemyDyingState>();

    private void UnSubscribeOnDeath()
        => _healthable.DiedEvent?.RemoveListener(SubscriptionOnDeath);

}
