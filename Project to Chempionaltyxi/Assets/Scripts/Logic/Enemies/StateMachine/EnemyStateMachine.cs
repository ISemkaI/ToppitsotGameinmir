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
        
    #region STATE_MACHINE
    private readonly List<IState> _enemyStates;
    private IState _currentState;
    #endregion

    public EnemyStateMachine(ICoroutineRunner coroutineRunner, Transform enemy, Transform player, PhysicsEventAdapter physicsEventAdapter, NavMeshAgent navMeshAgent)
    {
        _coroutineRunner = coroutineRunner;
        _enemy = enemy;
        _player = player;

        _physicsEventAdapter = physicsEventAdapter;
        _navMeshAgent = navMeshAgent;

        _enemyStates = new List<IState>
        {
            new EnemyMovementState(this, enemy, player, navMeshAgent, physicsEventAdapter),
            new EnemyShootingState(this, coroutineRunner, enemy, player, physicsEventAdapter),
        };
    }

    // Выходим из прежнего состояния, входим в новое.
    // Сложный шаблонный синтаксис
    public void SwitchState<TState>() where TState : notnull, IState
    {
        _currentState?.Exit();
        _currentState = _enemyStates.FirstOrDefault(x => x is IState);
        _currentState.Enter();
    }
}
