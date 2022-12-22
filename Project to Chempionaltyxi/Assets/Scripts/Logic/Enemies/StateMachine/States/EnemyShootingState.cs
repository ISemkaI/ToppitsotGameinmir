using UnityEngine;

public class EnemyShootingState : IState
{
    private readonly EnemyStateMachine _enemyStateMachine;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly Transform _enemy;
    private readonly Transform _player;
    private readonly PhysicsEventAdapter _physicsEventAdapter;

    public EnemyShootingState(EnemyStateMachine enemyStateMachine, ICoroutineRunner coroutineRunner, Transform enemy, Transform player, PhysicsEventAdapter physicsEventAdapter)
    {
        _enemyStateMachine = enemyStateMachine;
        _coroutineRunner = coroutineRunner;
        _enemy = enemy;
        _player = player;

        _physicsEventAdapter = physicsEventAdapter;
    }

    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}