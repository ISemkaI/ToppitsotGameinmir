using UnityEngine;

public class EnemyShootingState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly ICoroutineRunner _coroutineRunner;

    private readonly Transform _enemy;
    private readonly Transform _player;
    private readonly PhysicsEventAdapter _physicsEventAdapter;

    public EnemyShootingState(EnemyStateMachine enemyStateMachine, ICoroutineRunner coroutineRunner, Transform enemy,
        Transform player, PhysicsEventAdapter physicsEventAdapter)
    {
        _stateSwitcher = enemyStateMachine;
        _coroutineRunner = coroutineRunner;
        _enemy = enemy;
        _player = player;

        _physicsEventAdapter = physicsEventAdapter;
    }

    public void Enter()
    {

    }

    public void Exit()
    {
    }
}